using Microsoft.Data.SqlClient;
using System.Reflection;

using DatabaseRecursive.Models;
using DatabaseRecursive.Utilities;


namespace DatabaseRecursive;

internal class Program
{

    // global variables and constants
    static string AssemblyPath = Path.GetDirectoryName(
        Assembly.GetExecutingAssembly().Location);
    static string FilePath = Path.Combine(AssemblyPath, "Documents");
    const string DBArchitectureFile = "DropAndCreate-Category.sql";
    const string DataFile = "Classification des animaux.txt";
    const string DBName = "DBRecursive";

    static SqlConnection DBConnection = null;


    public static void Main()
    {
        StartProgram();

        // get data from file
        //Util.GetDataFromFile(FilePath, DataFile);
        //Util.DisplayData();

        // open DB
        SqlConnection SQLConnection = DBUtil.ConnectToSQLServer(DBName);
        if (SQLConnection != null)
        {
            // create tables
            //DBUtil.CreateTablesInDB(SQLConnection, FilePath, DBArchitectureFile);
            // insert data
            //DBUtil.InsertDataInDB(SQLConnection);
            // load data
            DBUtil.GetDataFromDB(SQLConnection);

            // display data
            //Util.DisplayData(true);

            // display full tree list
            //List<string> Elements = CreateHierarchicalList(true);
            List<string> Elements = CreateOrderedHierarchicalList(
                Category.Elements,
                new List<string>(),
                AddRootPrefix: true);

            Elements = Util.ExtendHierachyRepresentation(Elements);
            DisplayList(Elements);

        }
    }


    private static void StartProgram()
    {
        Console.WriteLine("Démonstration d'utilisation de données récursives dans une base de données.");
    }

    private static List<string> CreateHierarchicalList(
        bool AddRootPrefix = false)
    {
        List<string> Hierarchy = new List<string>();

        foreach (Category Element in Category.Elements)
        {
            string Prefix = new string(' ', Element.ParentIDs.Count * 2);
            if (AddRootPrefix || Element.ParentIDs.Count > 0)
                Prefix += "└ ";

            Hierarchy.Add(Prefix + Element);
        }

        return Hierarchy;
    }

    private static List<string> CreateOrderedHierarchicalList(
        List<Category> Elements,
        List<string> Hierarchy,
        int? IDElement = null,
        bool AddRootPrefix = false)
    {

        // get children
        List<Category> ChildrenElements = Elements
            .Where(e => e.IDParentCategory == IDElement)
            .OrderBy(e => e.Name)
            .ToList();

        foreach (Category Element in ChildrenElements)
        {
            string Prefix = new string(' ', Element.ParentIDs.Count * 2);
            if (AddRootPrefix || Element.ParentIDs.Count > 0)
                Prefix += "└ ";

            Hierarchy.Add(Prefix + Element);

            Hierarchy = CreateOrderedHierarchicalList(Elements, Hierarchy, Element.ID);
        }

        return Hierarchy;
    }

    private static void DisplayList(List<string> Elements)
    {
        Console.WriteLine();

        foreach (string Element in Elements) 
            Console.WriteLine(Element);
    }

}
