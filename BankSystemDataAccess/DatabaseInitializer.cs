using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;


namespace BankDataAccessLayer
{
    public class DatabaseInitializer
    {
        private static readonly string _DatabaseName = "BankSystemDB";

        public static void InitializeDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MasterConn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                string query = @"
                    SELECT COUNT(*)
                    FROM sys.databases
                    WHERE name = @DatabaseName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DatabaseName", _DatabaseName);

                    int databaseExists = Convert.ToInt32(command.ExecuteScalar());

                    if (databaseExists == 0)
                    {
                        CreateDatabase(connection);
                    }
                }
            }
        }

        private static void CreateDatabase(SqlConnection connection)
        {
            
            string scriptPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Database",
                "BankSystemDB.sql"
            );

            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(
                    "Database script was not found.",
                    scriptPath
                );
            }

            string script = File.ReadAllText(scriptPath);

            string[] batches = Regex.Split(
                script,
                @"^\s*GO\s*(?:--.*)?$",
                RegexOptions.Multiline | RegexOptions.IgnoreCase
            );

            foreach (string batch in batches)
            {
                string sql = batch.Trim();

                if (string.IsNullOrWhiteSpace(sql))
                    continue;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}