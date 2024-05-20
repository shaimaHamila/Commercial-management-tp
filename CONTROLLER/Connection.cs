using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLLER
{
   public class Connection
    {
        
           public static SqlConnection connecter()
            {
                SqlConnection connection = null;
                try
                    {
                        Console.WriteLine("Connect to SQL Server.");



                        string connectString = @"Data Source=DESKTOP-3MIQ4HF;Initial Catalog=OrderManagment;Integrated Security=True";

                        // Objet connection
                        connection = new SqlConnection(connectString);

                        Console.Write("Connecting to SQL Server ... ");
                        connection.Open();
                        Console.WriteLine("Connected to SQL server successfully 🥳.");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error connecting to SQL Server: " + ex.Message);
                    }
                return connection;
        }


        public static bool ExecuteCommand(SqlCommand query)
        {
            try
            {
                query.Connection = Connection.connecter();
                return query.ExecuteNonQuery() >= 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing command: " + ex.Message);
                return false;
            }
        }

        public static SqlDataReader ExecuteReader(string query)
        {
           SqlCommand command= new SqlCommand(query);

            command.Connection = Connection.connecter();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
    }
}

