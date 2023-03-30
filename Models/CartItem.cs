using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyEshop.Models;

public class CartItem
{
    #nullable disable
    public int Id { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }
    public decimal getTotalPrice()
    {
        return Quantity * Item.Price;
    }
}