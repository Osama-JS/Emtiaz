using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emtias.Data;
using Emtias.Models.Scaffolded;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Emtias.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ProductController> _logger;

        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment, ILogger<ProductController> logger)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products.Include(p => p.Restaurant);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Restaurant)
                .Include(p => p.Offers)
                .Include(p => p.Carts)
                .Include(p => p.OrderItems)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Helper method to upload icon
        private async Task<(bool Success, string FilePath, string ErrorMessage)> UploadIconAsync(IFormFile iconFile)
        {
            try
            {
                // Validate file size (5MB max)
                if (iconFile.Length > 5 * 1024 * 1024)
                {
                    return (false, "", "حجم الملف يجب أن يكون أقل من 5 ميجابايت");
                }

                // Validate file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".svg" };
                var fileExtension = Path.GetExtension(iconFile.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    return (false, "", "نوع الملف غير مدعوم. يرجى اختيار صورة بصيغة JPG, PNG, GIF, WebP, أو SVG");
                }

                // Create unique filename
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");

                // Ensure directory exists
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, fileName);

                // Save file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await iconFile.CopyToAsync(fileStream);
                }

                // Return relative path for database storage
                var relativePath = $"/images/products/{fileName}";
                return (true, relativePath, "");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading product icon");
                return (false, "", "حدث خطأ أثناء رفع الصورة");
            }
        }

        // Helper method to delete icon file
        private void DeleteIconFile(string iconPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(iconPath) && iconPath.StartsWith("/images/products/"))
                {
                    var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, iconPath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                        _logger.LogInformation($"Deleted product icon: {fullPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product icon: {iconPath}");
            }
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => !r.Deleted), "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EnName,IconLink,Deleted,State,CreateAt,RestaurantId")] Product product, IFormFile? iconFile = null)
        {
            try
            {
                _logger.LogInformation("Creating new product: {ProductName}", product.Name);

                // Custom validation
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    ModelState.AddModelError("Name", "اسم المنتج مطلوب ولا يمكن أن يكون فارغاً");
                }

                if (product.RestaurantId == null || product.RestaurantId == 0)
                {
                    ModelState.AddModelError("RestaurantId", "يجب اختيار مطعم للمنتج");
                }

                if (ModelState.IsValid)
                {
                    // Handle file upload if a file was provided
                    if (iconFile != null && iconFile.Length > 0)
                    {
                        var uploadResult = await UploadIconAsync(iconFile);
                        if (uploadResult.Success)
                        {
                            product.IconLink = uploadResult.FilePath;
                        }
                        else
                        {
                            ModelState.AddModelError("", uploadResult.ErrorMessage);
                            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => !r.Deleted), "Id", "Name", product.RestaurantId);
                            return View(product);
                        }
                    }

                    // Set default values
                    product.CreateAt = DateTime.Now;
                    if (string.IsNullOrEmpty(product.State))
                    {
                        product.State = "new";
                    }

                    _context.Add(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"تم إنشاء المنتج '{product.Name}' بنجاح";
                    _logger.LogInformation($"Product created successfully: {product.Name} (ID: {product.Id})");

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                TempData["ErrorMessage"] = $"حدث خطأ أثناء إنشاء المنتج: {ex.Message}";
                ModelState.AddModelError("", $"فشل في إنشاء المنتج. تفاصيل الخطأ: {ex.Message}");
            }

            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => !r.Deleted), "Id", "Name", product.RestaurantId);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Restaurant)
                .Include(p => p.Offers)
                .Include(p => p.OrderItems)
                .Include(p => p.Carts)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => !r.Deleted), "Id", "Name", product.RestaurantId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EnName,IconLink,Deleted,State,CreateAt,RestaurantId")] Product product, IFormFile? iconFile = null)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            try
            {
                _logger.LogInformation("Updating product: {ProductId} - {ProductName}", product.Id, product.Name);

                // Custom validation
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    ModelState.AddModelError("Name", "اسم المنتج مطلوب ولا يمكن أن يكون فارغاً");
                }

                if (product.RestaurantId == null || product.RestaurantId == 0)
                {
                    ModelState.AddModelError("RestaurantId", "يجب اختيار مطعم للمنتج");
                }

                if (ModelState.IsValid)
                {
                    // Get the original product to preserve the old icon path
                    var originalProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    if (originalProduct == null)
                    {
                        return NotFound();
                    }

                    // Handle file upload if a new file was provided
                    if (iconFile != null && iconFile.Length > 0)
                    {
                        var uploadResult = await UploadIconAsync(iconFile);
                        if (uploadResult.Success)
                        {
                            // Delete old icon if it exists
                            if (!string.IsNullOrEmpty(originalProduct.IconLink))
                            {
                                DeleteIconFile(originalProduct.IconLink);
                            }

                            product.IconLink = uploadResult.FilePath;
                        }
                        else
                        {
                            ModelState.AddModelError("", uploadResult.ErrorMessage);
                            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => !r.Deleted), "Id", "Name", product.RestaurantId);
                            return View(product);
                        }
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"تم تحديث المنتج '{product.Name}' بنجاح";
                    _logger.LogInformation($"Product updated successfully: {product.Name} (ID: {product.Id})");

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, "Concurrency error updating product ID: {ProductId}", product.Id);
                    TempData["ErrorMessage"] = "حدث تضارب أثناء التحديث. تم تعديل المنتج من قبل مستخدم آخر. يرجى إعادة تحميل الصفحة والمحاولة مرة أخرى";
                    ModelState.AddModelError("", "تم تعديل هذا المنتج من قبل مستخدم آخر. يرجى إعادة تحميل الصفحة والمحاولة مرة أخرى");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product ID: {ProductId}", product.Id);
                TempData["ErrorMessage"] = $"حدث خطأ أثناء تحديث المنتج: {ex.Message}";
                ModelState.AddModelError("", $"فشل في تحديث المنتج. تفاصيل الخطأ: {ex.Message}");
            }

            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => !r.Deleted), "Id", "Name", product.RestaurantId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Restaurant)
                .Include(p => p.Offers)
                .Include(p => p.OrderItems)
                .Include(p => p.Carts)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await _context.Products
                    .Include(p => p.Offers)
                    .Include(p => p.OrderItems)
                    .Include(p => p.Carts)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    // Delete associated icon file
                    if (!string.IsNullOrEmpty(product.IconLink))
                    {
                        DeleteIconFile(product.IconLink);
                    }

                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"تم حذف المنتج '{product.Name}' بنجاح";
                    _logger.LogInformation($"Product deleted successfully: {product.Name} (ID: {product.Id})");
                }
                else
                {
                    TempData["ErrorMessage"] = "المنتج غير موجود";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product ID: {ProductId}", id);
                TempData["ErrorMessage"] = $"حدث خطأ أثناء حذف المنتج: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        // API endpoint for uploading product icons via AJAX
        [HttpPost]
        public async Task<IActionResult> UploadIcon(IFormFile iconFile)
        {
            try
            {
                if (iconFile == null || iconFile.Length == 0)
                {
                    return Json(new { success = false, message = "لم يتم اختيار ملف" });
                }

                var uploadResult = await UploadIconAsync(iconFile);

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
                _logger.LogError(ex, "Error in UploadIcon API");
                return Json(new { success = false, message = "حدث خطأ أثناء رفع الصورة" });
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
