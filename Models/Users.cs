using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyEshop.Models;

public class Users
{
    #nullable disable
    [Key]
    public int UserId { get; set; }
    [Required]
    [MaxLength(300)]
    public string Email { get; set; }
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }
    [Required]
    public DateTime RegisterDate { get; set; }
    public bool IsAdmin { get; set; }
    public List<Order> Orders { get; set; }
}