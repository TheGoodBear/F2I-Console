using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database1
{
    internal class Program
    {

        public static void Main()
        {
            Console.WriteLine("Hello");
            SqlConnection Conn = ConnectToSQLServer();
            if (Conn != null)
                GetData(Conn);
        }


        public static SqlConnection ConnectToSQLServer()
        {
            Console.WriteLine("Getting Connection ...");

            //var datasource = @"DESKTOP-PC\SQLEXPRESS";//your server
            var database = "ConsoleDB1"; //your database name
            var username = "sa"; //username of server to connect
            var password = "password"; //password

            //your connection string 
            //string connString = @"Data Source=" + datasource + ";Initial Catalog="
            //            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            string ConnectionString =
                @"Server=(localdb)\MSSQLLocalDB;" +
                "Integrated Security=true;" +
                "Initial Catalog=" + database + ";";

            //create instanace of database connection
            SqlConnection Conn = new SqlConnection(ConnectionString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                Conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }

            return Conn;
        }


        public static void InsertData(
            SqlConnection Conn)
        {
            //create a new SQL Query using StringBuilder
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("INSERT INTO Student_details (Name, Email, Class) VALUES ");
            strBuilder.Append("(N'Harsh', N'harsh@gmail.com', N'Class X'), ");
            strBuilder.Append("(N'Ronak', N'ronak@gmail.com', N'Class X') ");

            string sqlQuery = strBuilder.ToString();
            using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
            {
                command.ExecuteNonQuery(); //execute the Query
                Console.WriteLine("Query Executed.");
            }

            strBuilder.Clear();
        }

        public static void GetData(
            SqlConnection Conn)
        {
            //create a new SQL Query using StringBuilder
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("SELECT * FROM Person");

            string sqlQuery = strBuilder.ToString();
            using (SqlCommand command = new SqlCommand(sqlQuery, Conn)) //pass SQL query created above and connection
            {
                SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
                while (SQLReader.Read())
                {
                    Console.WriteLine(
                        $"({SQLReader["Id"]}) - " +
                        $"{SQLReader["Name"]}");
                }

            }

            strBuilder.Clear();
        }

    }
}
