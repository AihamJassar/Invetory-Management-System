using Invetory_Management_System.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Invetory_Management_System.Services
{
    public class SupplierService
    {
        private readonly Database _db;

        public SupplierService()
        {
            _db = new Database();
        }

        public Supplier Add(Supplier supplier)
        {
            int id;
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO suppliers (name, address, phone) VALUES (@n, @a, @p)", conn);

                cmd.Parameters.AddWithValue("@n", supplier.Name);
                cmd.Parameters.AddWithValue("@a", supplier.Address);
                cmd.Parameters.AddWithValue("@p", supplier.Phone);

                cmd.ExecuteNonQuery();

                id = (int)cmd.LastInsertedId;
            }

            return new Supplier
            {
                Id = id,
                Name = supplier.Name,
                Address = supplier.Address,
                Phone = supplier.Phone,
            };
        }

        public void Update(Supplier supplier)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE suppliers SET name=@n, address=@a, phone=@p WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@n", supplier.Name);
                cmd.Parameters.AddWithValue("@a", supplier.Address);
                cmd.Parameters.AddWithValue("@p", supplier.Phone);
                cmd.Parameters.AddWithValue("@id", supplier.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM suppliers WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Supplier> GetAll()
        {
            List<Supplier> list = new List<Supplier>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM suppliers", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Supplier
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
