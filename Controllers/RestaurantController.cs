using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emtias.Data;
using Emtias.Models.Scaffolded;

namespace Emtias.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RestaurantController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Restaurant
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Restaurants.Include(r => r.Catgory);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Restaurant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.Catgory)
                .Include(r => r.Products)
                .Include(r => r.Offers)
                .Include(r => r.OrderItems)
                .Include(r => r.Carts)
                .Include(r => r.Reservations)
                .Include(r => r.RestaurantsComments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            ViewData["CatgoryId"] = new SelectList(_context.Catgories, "Id", "Name");
            return View();
        }

        // POST: Restaurant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EnName,Details,Address,IconLink,Deleted,CatgoryId,Lat,Lng")] Restaurant restaurant, IFormFile? iconFile = null)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload if a file was provided
                if (iconFile != null && iconFile.Length > 0)
                {
                    var uploadResult = await UploadIconAsync(iconFile);
                    if (uploadResult.Success)
                    {
                        restaurant.IconLink = uploadResult.FilePath;
                    }
                    else
                    {
                        ModelState.AddModelError("", uploadResult.ErrorMessage);
                        ViewData["CatgoryId"] = new SelectList(_context.Catgories, "Id", "Name", restaurant.CatgoryId);
                        return View(restaurant);
                    }
                }

                _context.Add(restaurant);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"تم إنشاء المطعم '{restaurant.Name}' بنجاح";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatgoryId"] = new SelectList(_context.Catgories, "Id", "Name", restaurant.CatgoryId);
            return View(restaurant);
        }

        // GET: Restaurant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            ViewData["CatgoryId"] = new SelectList(_context.Catgories, "Id", "Name", restaurant.CatgoryId);
            return View(restaurant);
        }

        // POST: Restaurant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EnName,Details,Address,IconLink,Deleted,CatgoryId,Lat,Lng")] Restaurant restaurant, IFormFile? iconFile = null)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Handle file upload if a file was provided
                    if (iconFile != null && iconFile.Length > 0)
                    {
                        // Get the old icon path to delete it later
                        var oldRestaurant = await _context.Restaurants.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
                        var oldIconPath = oldRestaurant?.IconLink;

                        var uploadResult = await UploadIconAsync(iconFile);
                        if (uploadResult.Success)
                        {
                            restaurant.IconLink = uploadResult.FilePath;

                            // Delete old icon file if it exists and is a local file
                            if (!string.IsNullOrEmpty(oldIconPath) && !oldIconPath.StartsWith("http"))
                            {
                                DeleteIconFile(oldIconPath);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", uploadResult.ErrorMessage);
                            ViewData["CatgoryId"] = new SelectList(_context.Catgories, "Id", "Name", restaurant.CatgoryId);
                            return View(restaurant);
                        }
                    }

                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"تم تحديث المطعم '{restaurant.Name}' بنجاح";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!RestaurantExists(restaurant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "حدث تضارب أثناء التحديث. تم تعديل المطعم من قبل مستخدم آخر. يرجى إعادة تحميل الصفحة والمحاولة مرة أخرى";
                        ModelState.AddModelError("", "تم تعديل هذا المطعم من قبل مستخدم آخر. يرجى إعادة تحميل الصفحة والمحاولة مرة أخرى");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"حدث خطأ أثناء تحديث المطعم: {ex.Message}";
                    ModelState.AddModelError("", $"فشل في تحديث المطعم. تفاصيل الخطأ: {ex.Message}");
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatgoryId"] = new SelectList(_context.Catgories, "Id", "Name", restaurant.CatgoryId);
            return View(restaurant);
        }

        // GET: Restaurant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.Catgory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Console.WriteLine($"Delete POST method called with ID: {id}");

                if (id <= 0)
                {
                    Console.WriteLine("Invalid ID provided");
                    return NotFound();
                }

                var restaurant = await _context.Restaurants.FindAsync(id);
                Console.WriteLine($"Restaurant found: {restaurant != null}");

                if (restaurant != null)
                {
                    Console.WriteLine($"Deleting restaurant: {restaurant.Name}");

                    // Delete associated icon file if it exists and is a local file
                    if (!string.IsNullOrEmpty(restaurant.IconLink) && !restaurant.IconLink.StartsWith("http"))
                    {
                        Console.WriteLine($"Deleting icon file: {restaurant.IconLink}");
                        DeleteIconFile(restaurant.IconLink);
                    }

                    _context.Restaurants.Remove(restaurant);
                    Console.WriteLine("Restaurant marked for deletion");
                }
                else
                {
                    Console.WriteLine("Restaurant not found in database");
                }

                await _context.SaveChangesAsync();
                Console.WriteLine("Changes saved to database");

                TempData["SuccessMessage"] = "تم حذف المطعم بنجاح";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete method: {ex.Message}");
                TempData["ErrorMessage"] = $"حدث خطأ أثناء حذف المطعم: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }

        // API endpoint for uploading icons via AJAX
        [HttpPost]
        public async Task<IActionResult> UploadIcon(IFormFile file)
        {
            try
            {
                var uploadResult = await UploadIconAsync(file);
                if (uploadResult.Success)
                {
                    return Json(new { success = true, filePath = uploadResult.FilePath });
                }
                else
                {
                    return Json(new { success = false, message = uploadResult.ErrorMessage });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"خطأ في رفع الملف: {ex.Message}" });
            }
        }

        // Helper method to upload icon files
        private async Task<(bool Success, string FilePath, string ErrorMessage)> UploadIconAsync(IFormFile file)
        {
            try
            {
                // Validate file
                if (file == null || file.Length == 0)
                {
                    return (false, null, "لم يتم اختيار ملف");
                }

                // Check file size (5MB max)
                if (file.Length > 5 * 1024 * 1024)
                {
                    return (false, null, "حجم الملف يجب أن يكون أقل من 5 ميجابايت");
                }

                // Check file extension
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".svg" };
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    return (false, null, "نوع الملف غير مدعوم. الأنواع المدعومة: JPG, PNG, GIF, WebP, SVG");
                }

                // Create unique filename
                var fileName = $"{Guid.NewGuid()}{fileExtension}";

                // Create upload directory if it doesn't exist
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "restaurants");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Save file
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Return relative path for database storage
                var relativePath = $"/images/restaurants/{fileName}";
                return (true, relativePath, null);
            }
            catch (Exception ex)
            {
                return (false, null, $"خطأ في رفع الملف: {ex.Message}");
            }
        }

        // Helper method to delete icon files
        private void DeleteIconFile(string iconPath)
        {
            try
            {
                if (string.IsNullOrEmpty(iconPath) || iconPath.StartsWith("http"))
                    return;

                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, iconPath.TrimStart('/'));
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            catch (Exception)
            {
                // Log error if needed, but don't throw
                // File deletion failure shouldn't break the application
            }
        }
    }
}
