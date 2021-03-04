using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Testing
{
    public class ProductRepository : IProductRepository  // This class is inside of the models folder (Product Model Creation)
    {
        private readonly IDbConnection _connection;
        public ProductRepository(IDbConnection connection) 
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("Select * from products");
        }
    }
}
