using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing
{
    public interface IProductRepository // This Interface is inside of the Models folder (Product Model Creation)
    {
        public IEnumerable<Product> GetAllProducts();
    }
}
