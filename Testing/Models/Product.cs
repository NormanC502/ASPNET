using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing
{
    public class Product   // This class is inside of the Models folder ()
    {
        public Product()
        {
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }
    }
}
