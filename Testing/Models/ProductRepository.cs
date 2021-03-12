using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public class ProductRepository : IProductRepository  // This class is inside of the models folder (Product Model Creation)
    {
        private readonly IDbConnection _connection;
        public ProductRepository(IDbConnection connection) 
        {
            _connection = connection;
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;
        }

        public void DeleteProduct(Product product)
        {
            _connection.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
                                       new { id = product.ProductID });
            _connection.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                                       new { id = product.ProductID });
            _connection.Execute("DELETE FROM Products WHERE ProductID = @id;",
                                       new { id = product.ProductID });
        }



        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("Select * from products");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _connection.Query<Category>("SELECT * FROM categories;"); 
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("Select * From Products Where ProductID = @id", new { id = id });
        }

        public void InsertProduct(Product productToInsert)
        {
                     _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });

        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("Update products Set Name = @name, Price = @price, Where ProductID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        

    }
}
