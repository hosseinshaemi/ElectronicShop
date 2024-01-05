using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEshop.Data;
namespace MyEshop.Controllers;

public class ProductController : Controller
{
    private MyEshopContext _context;
    public ProductController(MyEshopContext context)
    {
        _context = context;
    }

    [Route("Group/{id}/{name}")]
    public IActionResult ShowProductByGroupId(int id, string name)
    {
        ViewData["GroupName"] = name;
        var products = _context.CategoryToProducts
        .Where(p => p.CategoryId == id)
        .Include(p => p.Product)
        .Select(p => p.Product)
        .ToList();
        return View(model: products);
    }
}

