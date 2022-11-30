using Microsoft.Data.SqlClient;
using System.Text;
using DatabaseRecursive.Models;

namespace DatabaseRecursive.Utilities;

internal static class DBUtil
{

    public static SqlConnection ConnectToSQLServer(
        string DBName)
    {

        string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;" +
            "Integrated Security=true;" +
            "Initial Catalog=" + DBName + ";";

        //create instanace of database connection
        SqlConnection SQLConnection = new SqlConnection(ConnectionString);

        try
        {
            Console.WriteLine($"\nConnexion à la base {DBName}...");

            //open connection
            SQLConnection.Open();

            Console.WriteLine("Connexion réussie!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine($"*** Erreur de connexion :\n{e.Message}");
            return null;
        }

        return SQLConnection;
    }


    public static void CreateTablesInDB(
        SqlConnection SQLConnection,
        string FilePath,
        string FileName)
    {
        string DataFromFile = "";
        try
        {
            using StreamReader? MyStream = new StreamReader(
                $"{FilePath}\\{FileName}");
            {
                DataFromFile = MyStream.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n*** Erreur à la lecture du fichier {FileName} :\n {e.Message}");
            return;
        }

        try
        {
            using (SqlCommand SQLCommand =
                new SqlCommand(DataFromFile, SQLConnection))
            {
                SQLCommand.ExecuteNonQuery();
                Console.WriteLine("\nLes tables ont été créées dans la base.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n*** Erreur lors de la création des tables :\n{e.Message}");
        }
    }


    public static void InsertDataInDB(
    SqlConnection SQLConnection)
    {
        //create a new SQL Query using StringBuilder
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append(
            "INSERT INTO [Category] " +
            "([Name], [Description], [IDParentCategory]) " +
            "VALUES ");

        foreach (Category Element in Category.Elements)
        {
            strBuilder.Append(
                $"(N'{Element.Name.Replace("'", "''")}', " +
                $"N'{Element.Description.Replace("'", "''")}', " +
                $"{(Element.IDParentCategory == null ? "null" : Element.IDParentCategory)})");
            if (Element != Category.Elements.Last())
                strBuilder.Append(", ");
        }

        string SQLQuery = strBuilder.ToString();

        try
        {
            using (SqlCommand SQLCommand =
                new SqlCommand(SQLQuery, SQLConnection))
            {
                SQLCommand.ExecuteNonQuery();
                Console.WriteLine("\nLes données ont été créées dans la base.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n*** Erreur lors de la création des données :\n{e.Message}");
        }

        strBuilder.Clear();
    }


    public static void GetDataFromDB(
        SqlConnection SQLConnection)
    {
        Category.Elements.Clear();

        //create a new SQL Query using StringBuilder
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.Append(
            "SELECT " +
            "[Category].[ID], " +
            "[Category].[Name], " +
            "[Category].[Description], " +
            "[Category].[IDParentCategory] " +
            "FROM [Category]");

        string SQLQuery = strBuilder.ToString();
        using (SqlCommand command = new SqlCommand(SQLQuery, SQLConnection)) //pass SQL query created above and connection
        {
            SqlDataReader SQLReader = command.ExecuteReader(); //execute the Query
            while (SQLReader.Read())
            {
                Category.Elements.Add(new Category(
                    Convert.ToInt32(SQLReader["ID"]),
                    SQLReader["Name"].ToString(),
                    SQLReader["Description"].ToString(),
                    (Convert.IsDBNull(SQLReader["IDParentCategory"]) ? null : Convert.ToInt32(SQLReader["IDParentCategory"]))));
            }

        }

        strBuilder.Clear();
    }


}
