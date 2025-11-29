using Invetory_Management_System.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Invetory_Management_System.Services
{
    public class ProductService
    {
        private readonly Database _db;

        public ProductService()
        {
            _db = new Database();
        }

        public Product Add(Product product)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO products (name, category, quantity, price) VALUES (@n, @c, @q, @p)", conn);

                cmd.Parameters.AddWithValue("@n", product.Name);
                cmd.Parameters.AddWithValue("@c", product.Category);
                cmd.Parameters.AddWithValue("@q", product.Quantity);
                cmd.Parameters.AddWithValue("@p", product.Price);

                cmd.ExecuteNonQuery();

                product.Id = product.Id = (int)cmd.LastInsertedId;

                return product ;
            }
        }

        public void Update(Product product)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE products SET name=@n, category=@c, quantity=@q, price=@p WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@n", product.Name);
                cmd.Parameters.AddWithValue("@c", product.Category);
                cmd.Parameters.AddWithValue("@q", product.Quantity);
                cmd.Parameters.AddWithValue("@p", product.Price);
                cmd.Parameters.AddWithValue("@id", product.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM products WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM products", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Product
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Category = reader.GetString("category"),
                        Quantity = reader.GetInt32("quantity"),
                        Price = reader.GetDecimal("price")
                    });
                }
            }

            return list;
        }
    }
}
