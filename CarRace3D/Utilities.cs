using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace3D
{
    internal class Utilities
    {
        public static void WriteFile(
            string FilePath,
            string FileName,
            List<Tuple<int, int>> DataList)
        {

            using StreamWriter? MyStream = new StreamWriter(
                FilePath + FileName,
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


        //public static void ReadFile(
        //    string FilePath,
        //    string FileName)
        //{

        //    using StreamReader? MyStream = new StreamReader(FilePath + FileName);
        //    {
        //        string Result = MyStream.ReadLine();
        //        while (Result != null)
        //        {
        //            string[] StudentData = Result.Split(";");
        //            Students.Add(new Person(
        //                StudentData[0],
        //                StudentData[1],
        //                StudentData[2],
        //                Convert.ToInt32(StudentData[3]),
        //                (Person.eITLevel)Convert.ToInt32(StudentData[4]),
        //                Convert.ToInt32(StudentData[5])));
        //            Result = MyStream.ReadLine();
        //        }
        //    }

        //    Console.WriteLine($"Le fichier {FileName} a été lu.\n");
        //}
    }
}
