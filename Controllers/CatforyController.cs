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
    public class CatforyController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CatforyController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Catfory
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catgories.Include(c => c.Restaurants).ToListAsync());
        }

        // GET: Catfory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catgory = await _context.Catgories
                .Include(c => c.Restaurants)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catgory == null)
            {
                return NotFound();
            }

            return View(catgory);
        }

        // GET: Catfory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catfory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EnName,IconLink")] Catgory catgory, IFormFile? iconFile = null)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload if a file was provided
                if (iconFile != null && iconFile.Length > 0)
                {
                    var uploadResult = await UploadIconAsync(iconFile);
                    if (uploadResult.Success)
                    {
                        catgory.IconLink = uploadResult.FilePath;
                    }
                    else
                    {
                        ModelState.AddModelError("", uploadResult.ErrorMessage);
                        return View(catgory);
                    }
                }

                _context.Add(catgory);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"تم إنشاء القسم '{catgory.Name}' بنجاح";
                return RedirectToAction(nameof(Index));
            }
            return View(catgory);
        }

        // GET: Catfory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catgory = await _context.Catgories.FindAsync(id);
            if (catgory == null)
            {
                return NotFound();
            }
            return View(catgory);
        }

        // POST: Catfory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EnName,IconLink")] Catgory catgory, IFormFile? iconFile = null)
        {
            if (id != catgory.Id)
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
                        var oldCategory = await _context.Catgories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
                        var oldIconPath = oldCategory?.IconLink;

                        var uploadResult = await UploadIconAsync(iconFile);
                        if (uploadResult.Success)
                        {
                            catgory.IconLink = uploadResult.FilePath;

                            // Delete old icon file if it exists and is a local file
                            if (!string.IsNullOrEmpty(oldIconPath) && !oldIconPath.StartsWith("http"))
                            {
                                DeleteIconFile(oldIconPath);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", uploadResult.ErrorMessage);
                            return View(catgory);
                        }
                    }

                    _context.Update(catgory);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"تم تحديث القسم '{catgory.Name}' بنجاح";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!CatgoryExists(catgory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "حدث تضارب أثناء التحديث. تم تعديل القسم من قبل مستخدم آخر. يرجى إعادة تحميل الصفحة والمحاولة مرة أخرى";
                        ModelState.AddModelError("", "تم تعديل هذا القسم من قبل مستخدم آخر. يرجى إعادة تحميل الصفحة والمحاولة مرة أخرى");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"حدث خطأ أثناء تحديث القسم: {ex.Message}";
                    ModelState.AddModelError("", $"فشل في تحديث القسم. تفاصيل الخطأ: {ex.Message}");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catgory);
        }

        // GET: Catfory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catgory = await _context.Catgories
                .Include(c => c.Restaurants)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catgory == null)
            {
                return NotFound();
            }

            return View(catgory);
        }

        // POST: Catfory/Delete/5
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

                var catgory = await _context.Catgories.FindAsync(id);
                Console.WriteLine($"Category found: {catgory != null}");

                if (catgory != null)
                {
                    Console.WriteLine($"Deleting category: {catgory.Name}");

                    // Delete associated icon file if it exists and is a local file
                    if (!string.IsNullOrEmpty(catgory.IconLink) && !catgory.IconLink.StartsWith("http"))
                    {
                        Console.WriteLine($"Deleting icon file: {catgory.IconLink}");
                        DeleteIconFile(catgory.IconLink);
                    }

                    _context.Catgories.Remove(catgory);
                    Console.WriteLine("Category marked for deletion");
                }
                else
                {
                    Console.WriteLine("Category not found in database");
                }

                await _context.SaveChangesAsync();
                Console.WriteLine("Changes saved to database");

                TempData["SuccessMessage"] = "تم حذف القسم بنجاح";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete method: {ex.Message}");
                TempData["ErrorMessage"] = $"حدث خطأ أثناء حذف القسم: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool CatgoryExists(int id)
        {
            return _context.Catgories.Any(e => e.Id == id);
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
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "categories");
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
                var relativePath = $"/images/categories/{fileName}";
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
