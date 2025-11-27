using Invetory_Management_System.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

public class ProductService
{
    private string connectionString = "Server=.;Database=InventoryDB;Trusted_Connection=True;";

    public void Add(Product product)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Products (Name, Category, Quantity, Price) VALUES (@n,@c,@q,@p)", conn);
            cmd.Parameters.AddWithValue("@n", product.Name);
            cmd.Parameters.AddWithValue("@c", product.Category);
            cmd.Parameters.AddWithValue("@q", product.Quantity);
            cmd.Parameters.AddWithValue("@p", product.Price);
            cmd.ExecuteNonQuery();
        }
    }

    public void Update(Product product)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Products SET Name=@n, Category=@c, Quantity=@q, Price=@p WHERE Id=@id", conn);
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
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

    public List<Product> GetAll()
    {
        List<Product> list = new List<Product>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Product
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Category = (string)reader["Category"],
                    Quantity = (int)reader["Quantity"],
                    Price = (decimal)reader["Price"]
                });
            }
        }
        return list;
    }
}
