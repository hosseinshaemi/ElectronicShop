using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop.Models;
using MyEshop.Data;
namespace MyEshop.Pages.Admin;

public class AddModel : PageModel
{
#nullable disable
    private MyEshopContext _context;
    [BindProperty]
    public AddEditProductViewModel Product { get; set; }
    public AddModel(MyEshopContext context)
    {
        _context = context;
    }
    public void OnGet()
    {

    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        var item = new Item
        {
            Price = Product.Price ?? 0,
            QuantityInStock = Product.QuantityInStock ?? 0,
        };
        _context.Add(item);
        _context.SaveChanges();

        var prod = new Product
        {
            Name = Product.Name,
            Item = item,
            Description = Product.Description,
        };
        _context.Add(prod);
        _context.SaveChanges();
        prod.ItemId = prod.Id;
        _context.SaveChanges();

        if (Product.Picture?.Length > 0)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", prod.Id + Path.GetExtension(Product.Picture.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                Product.Picture.CopyTo(stream);
            }
        }
        return RedirectToPage("Index");
    }
}
