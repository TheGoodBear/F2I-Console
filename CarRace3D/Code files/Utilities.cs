using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRace2D.Code_files
{
    internal static class Utilities
    {

        public static void WriteFile<T>(
            string FilePath,
            string FileName,
            List<T> Data)
        {

            //using StreamWriter? MyStream = new StreamWriter(
            //    FilePath + FileName,
            //    false,
            //    Encoding.UTF8);
            //{
            //    foreach (Person CurrentPerson in Data)
            //    {
            //        MyStream.WriteLine(
            //            $"{CurrentPerson.LastName};" +
            //            $"{CurrentPerson.FirstName};" +
            //            $"{(int)CurrentPerson.Sex};" +
            //            $"{CurrentPerson.BirthYear};" +
            //            $"{(int)CurrentPerson.ITLevel};" +
            //            $"{(int)CurrentPerson.Location};" +
            //            $"{CurrentPerson.GroupNumber};" +
            //            $"{CurrentPerson.ProjectName};" +
            //            $"{(int)CurrentPerson.Technology}");
            //    }
            //}

            //Console.WriteLine($"Le fichier {FileName} a été écrit.\n");

        }

        public static void WriteFile(
            string FilePath,
            string FileName,
            List<Tuple<int, int>> DataList)
        {

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            FileName = FileName.Replace("<>", 
                DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + DataList.Count.ToString());

            using StreamWriter? MyStream = new StreamWriter(
                FilePath + "\\" + FileName,
                false,
                Encoding.UTF8);
            {
                foreach (Tuple<int, int> Data in DataList)
                {
                    MyStream.WriteLine(
                        $"{new string(' ', Data.Item1 - 1)}▓{new string(' ', Data.Item2 - 1)}▓");
                }
            }

            Console.WriteLine($"Le fichier {FileName} a été écrit.\n");

        }


        public static void ReadFile(
            string FilePath,
            string FileName)
        {

            //using StreamReader? MyStream = new StreamReader(FilePath + FileName);
            //{
            //    string Result = MyStream.ReadLine();
            //    while (Result != null)
            //    {
            //        string[] StudentData = Result.Split(";");
            //        Students.Add(new Person(
            //            StudentData[0],
            //            StudentData[1],
            //            (Person.eSex)Convert.ToInt32(StudentData[2]),
            //            Convert.ToInt32(StudentData[3]),
            //            (Person.eITLevel)Convert.ToInt32(StudentData[4]),
            //            (Person.eLocation)Convert.ToInt32(StudentData[5]),
            //            Convert.ToInt32(StudentData[6]),
            //            StudentData[7],
            //            (Person.eTechnology)Convert.ToInt32(StudentData[8])));
            //        Result = MyStream.ReadLine();
            //    }
            //}

            //Console.WriteLine($"Le fichier {FileName} a été lu.\n");
        }

        public static ConsoleKey GetKey()
        {
            ConsoleKeyInfo cki;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\nPress a key to display; press the 'x' key to quit.");

            // Your code could perform some useful task in the following loop. However,
            // for the sake of this example we'll merely pause for a quarter second.

            int Counter = 0;
            while (Console.KeyAvailable == false)
            {
                Console.SetCursorPosition(0, 4);
                Console.Write(Counter);
                Thread.Sleep(100); // Loop until input is entered.
                Counter++;
            }

            cki = Console.ReadKey(true);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("You pressed the '{0}' key.", cki.Key);

            return cki.Key;
        }


        public static void GetClassProperties<T>()
        {

            // get all properties of T
            PropertyInfo[] DataProperties = typeof(T).GetProperties(
                BindingFlags.FlattenHierarchy |
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static);

            foreach (PropertyInfo DataProperty in DataProperties)
            {
                Console.WriteLine(
                    $"{DataProperty.Name} (" +
                    $"{(DataProperty.CanRead ? "Read" : "")}" +
                    $"{(DataProperty.CanRead && DataProperty.CanWrite ? "/" : "")}" +
                    $"{(DataProperty.CanWrite ? "Write" : "")}) " +
                    $"");
            }

        }
    }
}
