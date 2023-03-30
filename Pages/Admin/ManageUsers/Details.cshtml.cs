using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshop.Data;
using MyEshop.Models;
namespace MyEshop.Pages.Admin.ManageUsers;

public class DetailsModel : PageModel
{
    private readonly MyEshop.Data.MyEshopContext _context;

    public DetailsModel(MyEshop.Data.MyEshopContext context)
    {
        _context = context;
    }

    public Users Users { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Users == null)
        {
            return NotFound();
        }

        var users = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
        if (users == null)
        {
            return NotFound();
        }
        else
        {
            Users = users;
        }
        return Page();
    }
}

