using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace OOP_MidProject.DL
{
    internal class DatabaseHelper
    {
        public static string ConnectionString = "server=----;port=3306;user=root;database =OOP_Project ; password =----; SslMode = Required;  ";

        public static MySqlConnection getConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static DataTable getData(string query)
        {
            using (var connection = getConnection())
            using (var command = new MySqlCommand(query, connection))
            using (var adapter = new MySqlDataAdapter(command))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static int Update(string query)
        {
            using (var connection = getConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                return command.ExecuteNonQuery();
            }
        }
    }
}
