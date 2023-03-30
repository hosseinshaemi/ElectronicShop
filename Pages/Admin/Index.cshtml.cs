using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshop.Models;
using MyEshop.Data;
namespace MyEshop.Pages.Admin;

public class IndexModel : PageModel
{
    #nullable disable
    private MyEshopContext _context;
    public IEnumerable<Product> Products { get; set; }
    public IndexModel(MyEshopContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        Products = _context.Products.Include(p => p.Item);
    }

    public void OnPost()
    {
        
    }
}
