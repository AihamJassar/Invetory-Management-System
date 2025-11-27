using Invetory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartInventorySystem.Services
{
    public class CustomerService
    {
        private string connectionString = @"Server=.;Database=InventoryDB;Trusted_Connection=True;";

        public void Add(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Customers (Name, Contact) VALUES (@n,@c)", conn);
                cmd.Parameters.AddWithValue("@n", customer.Name);
                cmd.Parameters.AddWithValue("@c", customer.Contact);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Customers SET Name=@n, Contact=@c WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@n", customer.Name);
                cmd.Parameters.AddWithValue("@c", customer.Contact);
                cmd.Parameters.AddWithValue("@id", customer.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Customers WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Customer
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Contact = (string)reader["Contact"]
                    });
                }
            }
            return list;
        }
    }
}
