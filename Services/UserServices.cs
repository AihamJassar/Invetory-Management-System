using Invetory_Management_System.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public User Register(string username, string password, string role)
        {
            // Check if user already exists
            if (GetUser(username) != null)
                return null;

            string hashed = HashPassword(password);
            int id;
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO users (username, password_hash, role) VALUES (@u, @p, @r)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", hashed);
                cmd.Parameters.AddWithValue("@r", role);

                cmd.ExecuteNonQuery();

                id  = (int)cmd.LastInsertedId;
            }

            return new User
            {
                Id = id,
                Username= username,
                Role = role
            };
        }

        public User Login(string username, string password)
        {
            var user = GetUser(username);

            if (user != null && VerifyPassword(password, user.PasswordHash))
                return user;

            return null;
        }

        public void Update(User user)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET username=@un, role=@r WHERE id=@id";
                if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                {
                    query = "UPDATE users SET username=@un, password_hash=@pass, role=@r WHERE id=@id";
                }
                    MySqlCommand cmd = new MySqlCommand(
                    query, conn);

                cmd.Parameters.AddWithValue("@un", user.Username);
                if(!string.IsNullOrWhiteSpace(user.PasswordHash))
                cmd.Parameters.AddWithValue("@pass", HashPassword(user.PasswordHash));
                cmd.Parameters.AddWithValue("@r", user.Role);
                cmd.Parameters.AddWithValue("@id", user.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM users WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
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

        public List<User> GetAll()
        {
            List<User> list = new List<User>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new User
                    {
                        Id = reader.GetInt32("id"),
                        Username = reader.GetString("username"),
                        Role = reader.GetString("role")
                    });
                }
            }

            return list;
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
