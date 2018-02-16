using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Trendy.Seeder
{
    public class MSSQLSeeder
    {
        const string connectionString = @"Server=mssql;Database=master;User=sa;Password=yourStrong(!)Password";

        public MSSQLSeeder()
        {
            try
            {
                ExecuteFromFile("CreateTrendyDatabase.sql");
            }
            catch (SqlException ex)
            {
                if (ex.Message != "Database 'Trendy' already exists. Choose a different database name.")
                {
                    throw ex;
                }
            }
            try
            {
                ExecuteFromFile("CreateTableProducts.sql");
            }
            catch (SqlException ex)
            {
                if (ex.Message != "There is already an object named 'Products' in the database.")
                {
                    throw ex;
                }
            }

            // Every startup would add more products!!!
            ExecuteFromFile("InsertProducts.sql");
        }

        public void ExecuteFromFile(string filename)
        {
            string sqlText = File.ReadAllText(filename);

            // GO statements blow up sql execution 
            // https://stackoverflow.com/questions/18596876/go-statements-blowing-up-sql-execution-in-net
            var scripts = Regex.Split(sqlText, @"(\s+|;|\n|\r)GO", RegexOptions.Multiline);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var splitScript in scripts.Where(i => !string.IsNullOrWhiteSpace(i)))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = splitScript;

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
    }
}
