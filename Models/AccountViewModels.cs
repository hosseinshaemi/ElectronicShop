using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyEshop.Models;

public class RegisterViewModel
{
    #nullable disable
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(300)]
    [EmailAddress]
    [Display(Name = "ایمیل")]
    public string Email { get; set; }
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(50)]
    [DataType(DataType.Password)]
    [Display(Name = "رمز عبور")]
    public string Password { get; set; }
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(50)]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "رمز عبور مطابقت ندارد")]
    [Display(Name = "تکرار رمز عبور")]
    public string RePassword { get; set; }
}

public class LoginViewModel
{
    #nullable disable
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(300)]
    [EmailAddress]
    [Display(Name = "ایمیل")]
    public string Email { get; set; }
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(50)]
    [DataType(DataType.Password)]
    [Display(Name = "رمز عبور")]
    public string Password { get; set; }
    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }
}


