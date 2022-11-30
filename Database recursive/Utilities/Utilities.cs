using DatabaseRecursive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRecursive.Utilities;

internal static class Util
{

    public static void GetDataFromFile(
        string FilePath,
        string FileName)
    {

        string[] DataFromFile;

        try
        {
            using StreamReader? MyStream = new StreamReader(
                $"{FilePath}\\{FileName}");
            {
                DataFromFile = MyStream.ReadToEnd().Split("\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n*** Erreur à la lecture du fichier {FileName} :\n {e.Message}");
            return;
        }

        Console.WriteLine($"\nLe fichier {FileName} a été lu.");

        DataParsing(DataFromFile.ToList());

    }


    public static void DataParsing(
        List<string> DataFromFile)
    {
        List<int> ParentIDs = new List<int>();
        int CurrentID = 1;
        int LastLevel = 0;

        foreach (string Data in DataFromFile)
        {
            //Console.WriteLine(Data);

            // count number of spaces at string start
            // result / 2 = indentation level
            int Level = Data
                .TakeWhile(c => c == ' ')
                .Count() / 2;

            // get name
            string Name = Data.Trim(new char[] { '└', ' ', '\r' });
            string Description = "";
            int ParenthesisIndex = Name.IndexOf('(');
            if (ParenthesisIndex > 0)
            {
                // there is a description
                Description = Name
                    .Substring(ParenthesisIndex)
                    .Trim(new char[] { '(', ')' });
                Name = Name.Substring(0, ParenthesisIndex).Trim();
            }

            if (Level > LastLevel)
            {
                ParentIDs.Add(CurrentID - 1);
                LastLevel = Level;
            }
            else if (Level < LastLevel)
            {
                ParentIDs.RemoveRange(ParentIDs.Count - (LastLevel - Level), LastLevel - Level);
                LastLevel = Level;
            }

            // create element
            int? ParentID = (ParentIDs.Count == 0 ? null : ParentIDs.Last());
            Category Element = new Category(
                CurrentID, Name, Description, ParentID);
            CurrentID++;

            // add element to collection
            Category.Elements.Add(Element);

        }

    }


    public static void DisplayData(
        bool DisplayWithHierarchy = false)
    {
        foreach (Category Element in Category.Elements)
        {
            if (DisplayWithHierarchy)
                Console.WriteLine(Element.DisplayWithHierarchy(true));
            else
                Console.WriteLine(Element.DisplayWithHierarchy());
        }
    }


    public static List<string> ExtendHierachyRepresentation(
        List<string> Elements)
    {

        for (int i = 0; i < Elements.Count; i++) 
        {
            if (i == 0)
                Elements[i] = Elements[i].Replace("└", "┌");
            else
                Elements[i - 1] = Elements[i - 1].Replace("  ", "│ ");

            if (i < Elements.Count - 1)
            {
                int LIndex = Elements[i].IndexOf("└");
                //if (LIndex >= 0 && Elements[i + 1].Substring(LIndex, 1) == "└")
                if (LIndex >= 0 && Elements[i + 1][LIndex] == '└')
                        Elements[i] = Elements[i].Replace("└", "├");
            }
        }

        for (int i = Elements.Count - 2; i >= 0; i--)
        {
            int iChar = 0;
            string cChar = Elements[i][iChar].ToString();
            string cCharUnder = Elements[i + 1][iChar].ToString();
            do
            {

                if (cChar == "│" && cCharUnder == " ")
                    Elements[i] =
                        Elements[i].Substring(0, iChar) +
                        " " +
                        Elements[i].Substring(iChar + 1);

                else if (cChar == "└" && cCharUnder == "│")
                    Elements[i] =
                        Elements[i].Substring(0, iChar) +
                        "├" +
                        Elements[i].Substring(iChar + 1);

                iChar++;
                cChar = Elements[i][iChar].ToString();
                cCharUnder = Elements[i + 1][iChar].ToString();

            } while (!Char.IsLetter(cChar, 0));

        }

        return Elements;
    }

}
