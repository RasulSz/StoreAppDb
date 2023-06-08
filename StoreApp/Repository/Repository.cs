using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StoreApp.Repository
{
    public class Repositories
    {
        ObservableCollection<Product> Products = new ObservableCollection<Product>();
        ObservableCollection<Category> Categories = new ObservableCollection<Category>();
        SqlConnection conn;
        string cs = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

        public Repositories()
        {
        }

        public async Task GetAllProduct(ObservableCollection<Product> _products)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                var query = "SELECT * FROM Products";

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;


                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Product product = new Product
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Quantity = int.Parse(reader[2].ToString()),
                            Price = int.Parse(reader[3].ToString()),
                            CategoryId = int.Parse(reader[4].ToString()),
                        };
                        _products.Add(product);
                    }
                }
            }
        }

        public async Task GetAllCategories(ObservableCollection<Category> _categories)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                var query = "SELECT * FROM Categories";

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;


                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Category category = new Category
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                        };
                        _categories.Add(category);
                    }
                }
            }
        }
    }
}
