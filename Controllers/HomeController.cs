using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Emtias.Models;
using Emtias.Data;
using Microsoft.EntityFrameworkCore;

namespace Emtias.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            // جمع الإحصائيات
            var stats = new
            {
                TotalCategories = await _context.Catgories.CountAsync(),
                ActiveCategories = await _context.Catgories.CountAsync(),

                TotalRestaurants = await _context.Restaurants.CountAsync(),
                ActiveRestaurants = await _context.Restaurants.Where(r => !r.Deleted).CountAsync(),
                DeletedRestaurants = await _context.Restaurants.Where(r => r.Deleted).CountAsync(),

                TotalProducts = await _context.Products.CountAsync(),
                ActiveProducts = await _context.Products.Where(p => p.State == "active").CountAsync(),
                NewProducts = await _context.Products.Where(p => p.State == "new").CountAsync(),
                InactiveProducts = await _context.Products.Where(p => p.State == "inactive").CountAsync(),

                TotalOffers = await _context.Offers.CountAsync(),
                ActiveOffers = await _context.Offers.Where(o => o.State == "active").CountAsync(),
                ExpiredOffers = await _context.Offers.Where(o => o.EndDate < DateTime.Now).CountAsync(),
                RestaurantsWithProducts = await _context.Restaurants.Where(r => r.Products.Any()).CountAsync(),
                CategoriesWithRestaurants = await _context.Catgories.Where(c => c.Restaurants.Any()).CountAsync(),
             
            };

            ViewBag.Stats = stats;
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading dashboard statistics");
            // في حالة الخطأ، إرسال إحصائيات فارغة
            ViewBag.Stats = new
            {
                TotalCategories = 0,
                ActiveCategories = 0,
                TotalRestaurants = 0,
                ActiveRestaurants = 0,
                DeletedRestaurants = 0,
                TotalProducts = 0,
                ActiveProducts = 0,
                NewProducts = 0,
                InactiveProducts = 0,
                TotalOffers = 0,
                ActiveOffers = 0,
                ExpiredOffers = 0,
                RestaurantsWithProducts = 0,
                CategoriesWithRestaurants = 0,
                NewProductsThisWeek = 0,
                NewOffersThisWeek = 0
            };
            return View();
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
