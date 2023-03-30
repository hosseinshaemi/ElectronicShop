using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyEshop.Models;

public class OrderDetail
{
    #nullable disable
    [Key]
    public int DetailId { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public decimal Price { get; set; }
    public int Count { get; set; }
    public Order Order { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}