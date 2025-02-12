using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows;
using System.IO;

namespace battleShips
{
    public class dataBaseManager
    {
        private string connectionString;
        public dataBaseManager(string dataBasePath)
        {

            connectionString = $"Data source={dataBasePath};Version=3;";
        }

        public void setupDatabaseAndInsertData(string username, string result, string gameDuration)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS GameResults (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        username TEXT NOT NULL,
                        result TEXT NOT NULL,
                        gameDuration TEXT NOT NULL
                );";

                    using (SQLiteCommand createTable = new SQLiteCommand(createTableQuery, connection))
                    {
                        createTable.ExecuteNonQuery();
                        Console.WriteLine("O pinakas dimiourgithike i iparxei idi");
                    }

                    string insertQuery = @"
                    INSERT INTO GameResults (username, result, gameDuration)
                    VALUES (@username, @result, @gameDuration);";

                    using (SQLiteCommand insertToTable = new SQLiteCommand(insertQuery, connection))
                    {
                        insertToTable.Parameters.AddWithValue("@username", username);
                        insertToTable.Parameters.AddWithValue("@result", result);
                        insertToTable.Parameters.AddWithValue("@gameDuration", gameDuration);

                        insertToTable.ExecuteNonQuery();
                        Console.WriteLine("Ta dedomena exoun isaxthei me epitixia stin vasi.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sfalma stin eisagogi dedomenon stin vasi: {ex.Message}");
            }
        }
    }
}