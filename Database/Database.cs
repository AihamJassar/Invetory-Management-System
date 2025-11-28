using MySql.Data.MySqlClient;


    public class Database
    {
        private readonly string connectionString =
            "server=localhost;database=inventorydb;user=root;password=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }

