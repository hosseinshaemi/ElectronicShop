using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshop.Data;
using MyEshop.Models;
namespace MyEshop.Pages.Admin;

public class EditModel : PageModel
{
    #nullable disable
    private MyEshopContext _context;
    [BindProperty]
    public AddEditProductViewModel Product { get; set; }
    public EditModel(MyEshopContext context)
    {
        _context = context;
    }
    public void OnGet(int id)
    {
        Product = _context.Products
        .Include(p => p.Item)
        .Where(p => p.Id == id)
        .Select(s => new AddEditProductViewModel
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            QuantityInStock = s.Item.QuantityInStock,
            Price = s.Item.Price,
        }).FirstOrDefault();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();
        
        var product = _context.Products.Find(Product.Id);
        var item = _context.Items.First(p => p.Id == product.ItemId);

        product.Name = Product.Name;
        product.Description = Product.Description;
        item.Price = Product.Price ?? 0;
        item.QuantityInStock = Product.QuantityInStock ?? 0;

        _context.SaveChanges();
        if (Product.Picture?.Length > 0)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", product.Id + Path.GetExtension(Product.Picture.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                Product.Picture.CopyTo(stream);
            }
        }

        return RedirectToPage("Index");
    }
}

