﻿using StoreApp.Models;
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
        public async void Insert(string name, int price, int quantity)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                string query = $@" INSERT INTO Products([Name],[Price],[Quantity])
                                VALUES(@name,@price,@quantity)";

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;

                var paramName = new SqlParameter();
                paramName.ParameterName = "@name";
                paramName.SqlDbType = SqlDbType.NVarChar;
                paramName.Value = name;

                var paramPrice = new SqlParameter();
                paramPrice.ParameterName = "@price";
                paramPrice.SqlDbType = SqlDbType.Int;
                paramPrice.Value = price;

                var paramQuantity = new SqlParameter();
                paramQuantity.ParameterName = "@quantity";
                paramQuantity.SqlDbType = SqlDbType.Int;
                paramQuantity.Value = quantity;

                command.Parameters.Add(paramName);
                command.Parameters.Add(paramPrice);
                command.Parameters.Add(paramQuantity);

                using (var reader = await command.ExecuteReaderAsync())
                {

                }
            }
        }
    }
}
