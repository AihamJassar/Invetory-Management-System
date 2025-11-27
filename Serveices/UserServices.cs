using Invetory_Management_System.Models;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public class UserService
{
    private string connectionString = "Server=.;Database=InventoryDB;Trusted_Connection=True;";

    public bool Register(string username, string password, string role)
    {
        if (GetUser(username) != null) return false;

        string hashed = HashPassword(password);
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, PasswordHash, Role) VALUES (@u,@p,@r)", conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", hashed);
            cmd.Parameters.AddWithValue("@r", role);
            cmd.ExecuteNonQuery();
        }
        return true;
    }

    public User Login(string username, string password)
    {
        var user = GetUser(username);
        if (user != null && VerifyPassword(password, user.PasswordHash))
            return user;
        return null;
    }

    private User GetUser(string username)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username=@u", conn);
            cmd.Parameters.AddWithValue("@u", username);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = (int)reader["Id"],
                    Username = (string)reader["Username"],
                    PasswordHash = (string)reader["PasswordHash"],
                    Role = (string)reader["Role"]
                };
            }
        }
        return null;
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }

    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }
}
