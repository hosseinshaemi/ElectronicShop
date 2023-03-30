using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyEshop.Models;

public class Cart
{
    public int OrderId { get; set; }
    public List<CartItem> CartItems { get; set; }
    public Cart()
    {
        CartItems = new List<CartItem>();
    }
    public void addItem(CartItem item)
    {
        #nullable disable
        if (CartItems.Exists(im => im.Item.Id == item.Item.Id))
            CartItems.Find(i => i.Item.Id == item.Item.Id).Quantity += 1;
        else
            CartItems.Add(item);
    }

    public void removeItem(int itemId)
    {
        var item = CartItems.SingleOrDefault(i => i.Item.Id == itemId);
        if (item?.Quantity <= 1)
            CartItems.Remove(item);
        else if (item != null)
            item.Quantity -= 1;
    }
}