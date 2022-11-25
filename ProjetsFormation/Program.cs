using Microsoft.Data.SqlClient;
using ProjetsFormation.Models;
using System.Reflection;
using System.Text;

namespace ProjetsFormation
{
    internal class Program
    {
        // global constants and variables
        static string AssemblyPath = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location);
        static string FilePath = Path.Combine(AssemblyPath, "Data");
        static SqlConnection DBConnection = null;

        public static List<Person> Persons = new List<Person>();
        public static List<Group> Groups = new List<Group>();
        public static List<Project> Projects = new List<Project>();


        public static void Main()
        {
            GetDataFromFiles();
            //PrintCollections();
            DBConnection = ConnectToSQLServer();
            InsertData(DBConnection);

            DBConnection.Close();
            DBConnection.Dispose();
        }


        private static void GetDataFromFiles()
        {
            ReadFile(FilePath, "Person.csv", typeof(Person));
            ReadFile(FilePath, "Group.csv", typeof(Group));
            ReadFile(FilePath, "Project.csv", typeof(Project));
        }

        private static void PrintCollections()
        {
            PrintCollection(Persons);
            PrintCollection(Groups);
            PrintCollection(Projects);
        }

        private static void PrintCollection<T>(
            List<T> MyList)
        {
            foreach (var Data in MyList)
                Console.WriteLine(Data);
        }

        public static void ReadFile(
            string FilePath,
            string FileName,
            Type Model)
        {

            using StreamReader? MyStream = new StreamReader(
                $"{FilePath}\\{FileName}");
            {
                string Result = MyStream.ReadLine();
                while (Result != null)
                {
                    string[] Data = Result.Split(";");

                    if (Model == typeof(Person))
                        Persons.Add(new Person(Data));
                    else if (Model == typeof(Group))
                        Groups.Add(new Group(Data));
                    if (Model == typeof(Project))
                        Projects.Add(new Project(Data));

                    Result = MyStream.ReadLine();
                }
            }

            Console.WriteLine($"\nLe fichier {FileName} a été lu.");
        }


        public static SqlConnection ConnectToSQLServer()
        {
            Console.WriteLine("Getting Connection ...");

            //var datasource = @"DESKTOP-PC\SQLEXPRESS";//your server
            var database = "ProjectsFormation"; //your database name
            //var username = "sa"; //username of server to connect
            //var password = "password"; //password

            //your connection string 
            //string connString = @"Data Source=" + datasource + ";Initial Catalog="
            //            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            string ConnectionString =
                @"Server=(localdb)\MSSQLLocalDB;" +
                "Integrated Security=true;" +
                "Initial Catalog=" + database + ";";

            //create instanace of database connection
            SqlConnection DBConnection =
                new SqlConnection(ConnectionString);

            try
            {
                Console.WriteLine("Opening Connection ...");

                //open connection
                DBConnection.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }

            return DBConnection;
        }

        public static void InsertData(
            SqlConnection DBConnection)
        {
            //create a new SQL Query using StringBuilder

            // for Project table
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(
                "INSERT INTO [Project] " +
                "([Name], [Description]) " +
                "VALUES ");
            for (int Line = 0; Line < Projects.Count; Line++)
            {
                // .Replace("'", "''") because SQL use ' to delimit strings (and not " as in C#)
                strBuilder.Append(
                    $"(N'{Projects[Line].Name.Replace("'", "''")}', " +
                    $"N'{Projects[Line].Description.Replace("'", "''")}')");
                if (Line < Projects.Count - 1)
                    strBuilder.Append(", ");
            }
            string SQLQuery = strBuilder.ToString();
            ExecuteSQLNonQuery(DBConnection, SQLQuery);

            // for Group table
            strBuilder = new StringBuilder();
            strBuilder.Append(
                "INSERT INTO [Group] " +
                "(Number, Name, Technology, IdProject) VALUES ");
            for (int Line = 0; Line < Groups.Count; Line++)
            {
                strBuilder.Append(
                    $"({Groups[Line].Number}, " +
                    $"N'{Groups[Line].Name.Replace("'", "''")}', " +
                    $"{(int)Groups[Line].Technology}, " +
                    $"{Groups[Line].IdProject})");
                if (Line < Groups.Count - 1)
                    strBuilder.Append(", ");
            }
            SQLQuery = strBuilder.ToString();
            ExecuteSQLNonQuery(DBConnection, SQLQuery);

            // for Person table
            strBuilder = new StringBuilder();
            strBuilder.Append(
                "INSERT INTO [Person] " +
                "(LastName, FirstName, Sex, BirthYear, ITLevel, Location, IdGroup) VALUES ");
            for (int Line = 0; Line < Persons.Count; Line++)
            {
                strBuilder.Append(
                    $"(N'{Persons[Line].LastName.Replace("'", "''")}', " +
                    $"N'{Persons[Line].FirstName.Replace("'", "''")}', " +
                    $"{(int)Persons[Line].Sex}, " +
                    $"{Persons[Line].BirthYear}, " +
                    $"{(int)Persons[Line].ITLevel}, " +
                    $"{(int)Persons[Line].Location}, " +
                    $"{Persons[Line].IdGroup})");
                if (Line < Persons.Count - 1)
                    strBuilder.Append(", ");
            }
            SQLQuery = strBuilder.ToString();
            ExecuteSQLNonQuery(DBConnection, SQLQuery);

            strBuilder.Clear();
        }

        private static void ExecuteSQLNonQuery(
            SqlConnection DBConnection,
            string SQLQuery)
        {

            try
            {
                using (SqlCommand Command = new SqlCommand(SQLQuery, DBConnection)) //pass SQL query created above and connection
                {
                    int Lines = Command.ExecuteNonQuery(); //execute the Query
                    Console.WriteLine($"\n{Lines} enregistrements ont été traités par la requête\n{SQLQuery}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

    }
}
