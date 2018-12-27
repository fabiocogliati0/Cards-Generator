using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cards_Generator.Source;
using Cards_Generator.Core;
using System.Data;
using System.Data.SqlClient;

namespace Cards_Generator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Name name1 = new Name();

            string connectionString = ("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\Fabio\\Desktop\\Cards Generator\\Cards Generator\\Resources\\DB\\DB.mdf\"; Integrated Security = True");
            SqlConnection connection = new SqlConnection(connectionString);
                
            
            string queryString = "SELECT Name FROM EnchantmentsTable";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = queryString;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string name = reader["Name"].ToString();

                int a = 3;
            }


        }
    }
}
