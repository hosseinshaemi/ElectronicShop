using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MyEshop.Models;
using MyEshop.Data;

namespace MyEshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyEshopContext _context;

    public HomeController(ILogger<HomeController> logger, MyEshopContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(model: products);
    }

    public IActionResult Detail(int id)
    {
        var product = _context.Products
        .Include(p => p.Item)
        .SingleOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        var categories = _context.Products.Where(p => p.Id == id)
        .SelectMany(c => c.CategoryToProducts).Select(ca => ca.Category)
        .ToList();

        var vm = new DetailsViewModel
        {
            Product = product,
            Categories = categories,
        };

        return View(model: vm);
    }

    [Authorize]
    public IActionResult AddToCart(int ItemId)
    {
    #nullable disable
        var product = _context.Products
        .Include(p => p.Item)
        .SingleOrDefault(p => p.ItemId == ItemId);
        if (product != null)
        {
            int userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
                    .ToString()
            );
            var order = _context.Orders.FirstOrDefault(
                o => o.UserId == userId && !o.IsFinaly
            );
            if (order != null)
            {
                var orderDetail = _context
                .OrderDetails
                .FirstOrDefault(o =>
                    o.OrderId == order.OrderId &&
                    o.ProductId == product.Id
                );
                if (orderDetail != null)
                {
                    orderDetail.Count++;
                }
                else
                {
                    _context.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1,
                    });
                }
            }
            else
            {
                order = new Order
                {
                    IsFinaly = false,
                    CreateDate = DateTime.Now,
                    UserId = userId,
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                _context.OrderDetails.Add(new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = product.Id,
                    Price = product.Item.Price,
                    Count = 1,
                });
            }
            _context.SaveChanges();
        }

        return RedirectToAction("ShowCart");
    }

    [Authorize]
    public IActionResult ShowCart()
    {
        int userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
                    .ToString()
        );
        var order = _context.Orders.Where(o => o.UserId == userId&&!o.IsFinaly)
        .Include(o => o.OrderDetails).ThenInclude(c => c.Product)
        .FirstOrDefault();

        return View(order);
    }

    [Authorize]
    public IActionResult RemoveCart(int detailId)
    {
        var orderDetail = _context.OrderDetails.Find(detailId);
        _context.Remove(orderDetail);
        _context.SaveChanges();
        return RedirectToAction("ShowCart");
    }

    [Route("ContactUs")]
    public IActionResult ContactUs()
    {
        return View();
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
