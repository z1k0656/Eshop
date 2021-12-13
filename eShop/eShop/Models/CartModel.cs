using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class CartModel
    {
        public List<CartItem> CarList { get; set; } = new();
        public double TotalPrice => CarList.Sum(x => x.Total);
    }
}
