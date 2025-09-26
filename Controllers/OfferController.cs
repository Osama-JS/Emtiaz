using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emtias.Data;
using Emtias.Models.Scaffolded;

namespace Emtias.Controllers
{
    public class OfferController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OfferController> _logger;

        public OfferController(AppDbContext context, ILogger<OfferController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Offer
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Offers.Include(o => o.Product).Include(o => o.Restaurant);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Offer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers
                .Include(o => o.Product)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offer/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products.Where(p => p.Deleted != true), "Id", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => r.Deleted != true), "Id", "Name");
            return View();
        }

        // POST: Offer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RestaurantId,ProductId,Price,DeleverCost,Discount,StartDate,EndDate,State,Units")] Offer offer)
        {
            try
            {
                _logger.LogInformation("Creating new offer: {OfferName}", offer.Name);

                // Custom validation
                if (string.IsNullOrWhiteSpace(offer.Name))
                {
                    ModelState.AddModelError("Name", "اسم العرض مطلوب ولا يمكن أن يكون فارغاً");
                }

                if (offer.RestaurantId == null || offer.RestaurantId == 0)
                {
                    ModelState.AddModelError("RestaurantId", "يجب اختيار مطعم للعرض");
                }

                if (offer.Price <= 0)
                {
                    ModelState.AddModelError("Price", "سعر العرض يجب أن يكون أكبر من صفر");
                }

                if (ModelState.IsValid)
                {
                    _context.Add(offer);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Offer created successfully: {OfferId}", offer.Id);
                    TempData["SuccessMessage"] = "تم إنشاء العرض بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating offer: {OfferName}", offer.Name);
                TempData["ErrorMessage"] = $"حدث خطأ أثناء إنشاء العرض: {ex.Message}";
                ModelState.AddModelError("", $"فشل في إنشاء العرض. تفاصيل الخطأ: {ex.Message}");
            }

            ViewData["ProductId"] = new SelectList(_context.Products.Where(p => p.Deleted != true), "Id", "Name", offer.ProductId);
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => r.Deleted != true), "Id", "Name", offer.RestaurantId);
            return View(offer);
        }

        // GET: Offer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products.Where(p => p.Deleted != true), "Id", "Name", offer.ProductId);
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => r.Deleted != true), "Id", "Name", offer.RestaurantId);
            return View(offer);
        }

        // POST: Offer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RestaurantId,ProductId,Price,DeleverCost,Discount,StartDate,EndDate,State,Units")] Offer offer)
        {
            if (id != offer.Id)
            {
                return NotFound();
            }

            try
            {
                _logger.LogInformation("Updating offer: {OfferId} - {OfferName}", offer.Id, offer.Name);

                // Custom validation
                if (string.IsNullOrWhiteSpace(offer.Name))
                {
                    ModelState.AddModelError("Name", "اسم العرض مطلوب ولا يمكن أن يكون فارغاً");
                }

                if (offer.RestaurantId == null || offer.RestaurantId == 0)
                {
                    ModelState.AddModelError("RestaurantId", "يجب اختيار مطعم للعرض");
                }

                if (offer.Price <= 0)
                {
                    ModelState.AddModelError("Price", "سعر العرض يجب أن يكون أكبر من صفر");
                }

                if (ModelState.IsValid)
                {
                    _context.Update(offer);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Offer updated successfully: {OfferId}", offer.Id);
                    TempData["SuccessMessage"] = "تم تحديث العرض بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!OfferExists(offer.Id))
                {
                    return NotFound();
                }
                else
                {
                    TempData["ErrorMessage"] = "حدث تضارب أثناء التحديث. تم تعديل العرض من قبل مستخدم آخر. يرجى إعادة تحميل الصفحة والمحاولة مرة أخرى";
                    ModelState.AddModelError("", "تم تعديل هذا العرض من قبل مستخدم آخر. يرجى إعادة تحميل الصفحة والمحاولة مرة أخرى");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating offer ID: {OfferId}", offer.Id);
                TempData["ErrorMessage"] = $"حدث خطأ أثناء تحديث العرض: {ex.Message}";
                ModelState.AddModelError("", $"فشل في تحديث العرض. تفاصيل الخطأ: {ex.Message}");
            }

            ViewData["ProductId"] = new SelectList(_context.Products.Where(p => p.Deleted != true), "Id", "Name", offer.ProductId);
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => r.Deleted != true), "Id", "Name", offer.RestaurantId);
            return View(offer);
        }

        // GET: Offer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers
                .Include(o => o.Product)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _logger.LogInformation("Deleting offer ID: {OfferId}", id);

                var offer = await _context.Offers.FindAsync(id);
                if (offer != null)
                {
                    _context.Offers.Remove(offer);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Offer deleted successfully: {OfferId}", id);
                    TempData["SuccessMessage"] = "تم حذف العرض بنجاح";
                }
                else
                {
                    TempData["ErrorMessage"] = "العرض غير موجود";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting offer ID: {OfferId}", id);
                TempData["ErrorMessage"] = $"حدث خطأ أثناء حذف العرض: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool OfferExists(int id)
        {
            return _context.Offers.Any(e => e.Id == id);
        }


    }
}
