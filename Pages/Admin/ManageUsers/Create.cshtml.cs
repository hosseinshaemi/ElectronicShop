using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEshop.Data;
using MyEshop.Models;
namespace MyEshop.Pages.Admin.ManageUsers;

public class CreateModel : PageModel
{
    #nullable disable
    private readonly MyEshop.Data.MyEshopContext _context;

    public CreateModel(MyEshop.Data.MyEshopContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Users Users { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || _context.Users == null || Users == null)
        {
            return Page();
        }

        _context.Users.Add(Users);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

