using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyEshop.Models;

public class AddEditProductViewModel
{
    #nullable disable
    public int Id { get; set; }
    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Name { get; set; }
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Description { get; set; }
    [Display(Name = "قیمت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public decimal? Price { get; set; }
    [Display(Name = "موجودی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int? QuantityInStock { get; set; }
    [Display(Name = "تصویر محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public IFormFile Picture { get; set; }
}