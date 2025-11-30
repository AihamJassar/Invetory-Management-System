using Invetory_Management_System.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Invetory_Management_System.Services
{
    public class CustomerService
    {
        private readonly Database _db;

        public CustomerService()
        {
            _db = new Database();
        }

        public Customer Add(Customer customer)
        {
            int id;
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO customers (name, address, phone) VALUES (@n, @a, @p)", conn);

                cmd.Parameters.AddWithValue("@n", customer.Name);
                cmd.Parameters.AddWithValue("@a", customer.Address);
                cmd.Parameters.AddWithValue("@p", customer.Phone);

                cmd.ExecuteNonQuery();

                id = (int)cmd.LastInsertedId;
            }

            return new Customer
            {
                Id = id,
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
            };
        }

        public void Update(Customer customer)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE customers SET name=@n, address=@a, phone=@p WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@n", customer.Name);
                cmd.Parameters.AddWithValue("@a", customer.Address);
                cmd.Parameters.AddWithValue("@p", customer.Phone);
                cmd.Parameters.AddWithValue("@id", customer.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM customers WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM customers", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Customer
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Address = reader.GetString("address"),
                        Phone = reader.GetString("phone")
                    });
                }
            }

            return list;
        }
    }
}
