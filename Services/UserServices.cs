using Invetory_Management_System.Models;
using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Invetory_Management_System.Services
{
    public class UserService
    {
        private readonly Database _db;

        public UserService()
        {
            _db = new Database();
        }

        public bool Register(string username, string password, string role)
        {
            // Check if user already exists
            if (GetUser(username) != null)
                return false;

            string hashed = HashPassword(password);

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO users (username, password_hash, role) VALUES (@u, @p, @r)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            User user = null;

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM users WHERE username=@u LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32("id"),
                        Username = reader.GetString("username"),
                        PasswordHash = reader.GetString("password_hash"),
                        Role = reader.GetString("role")
                    };
                }
            }

            return user;
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
}
