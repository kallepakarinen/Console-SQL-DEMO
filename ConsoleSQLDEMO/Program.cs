using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSQLDEMO
{
    class Program
    {
        static void Main(string[] args)
        {

            string connStr = "---Your connection string---";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            Console.WriteLine("Anna SQL-lause");
            string syote = Console.ReadLine();
            string sql = syote;
            SqlCommand cmd = new SqlCommand(sql, conn); SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Hakusi " + syote + " Tuottaa seuraavan tuloksen tuloksen \n\r");
 
            while (reader.Read())
            {
                
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnNames = reader.GetName(i).ToString();
                    string columns = reader.GetValue(i).ToString();
                    Console.WriteLine(columnNames + " - " + columns);                    
                }
                Console.WriteLine("---------------------");            
            }
            // resurssien vapautus 
            reader.Close();
            cmd.Dispose();
            conn.Dispose();

            Console.ReadKey();
        }
    }
}
