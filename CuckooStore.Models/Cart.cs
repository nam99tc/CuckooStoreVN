using System.Collections.Generic;
using System.Linq;

namespace CuckooStore.Models
{
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Product pro, int qty)
        {
            var item = items.FirstOrDefault(x => x._product.ProductID == pro.ProductID);
            if (item == null)
            {
                items.Add(new CartItem()
                {
                    _product = pro,
                    _quatity = qty
                });
            }
            else
            {
                item._quatity += qty;
            }
        }
        public void Remove_Cart(int id)
        {
            items.RemoveAll(x => x._product.ProductID == id);
        }
        //Total Cart
        public double Total_Money()
        {
            var total = items.Sum(s => s._product.UnitPrice * s._quatity);
            return (double)total;
        }
    }
}
