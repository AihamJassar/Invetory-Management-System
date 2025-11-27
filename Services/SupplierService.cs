using Invetory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace SmartInventorySystem.Services
{
    public class SupplierService
    {
        private string connectionString = @"Server=.;Database=InventoryDB;Trusted_Connection=True;";

        public void Add(Supplier supplier)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Suppliers (Name, Contact) VALUES (@n,@c)", conn);
                cmd.Parameters.AddWithValue("@n", supplier.Name);
                cmd.Parameters.AddWithValue("@c", supplier.Contact);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Supplier supplier)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Suppliers SET Name=@n, Contact=@c WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@n", supplier.Name);
                cmd.Parameters.AddWithValue("@c", supplier.Contact);
                cmd.Parameters.AddWithValue("@id", supplier.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Suppliers WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Supplier> GetAll()
        {
            List<Supplier> list = new List<Supplier>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Supplier
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
