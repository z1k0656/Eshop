using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class CartItem
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get;set; }
    }
}
