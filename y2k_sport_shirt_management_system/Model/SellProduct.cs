using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace y2k_sport_shirt_management_system.Model
{
    public class SellProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public decimal PtoductTotalPrice { get; set; }
        public string ProductCategory { get; set; }
        public string sellerName { get; set; }
    }
}
