using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarRaceV4
{
    internal static class Utilities
    {

        public static int AskNumber(
            string Message,
            int LowestValue = 0,
            int HighestValue = 100)
        {
            // Méthode utilitaire pour demander à l'utilisateur
            // un nombre entier entre 2 bornes incluses
            // Return value : int
            // Parameters :
            //      Message (sting) : message à afficher à l'utilisateur
            //      LowestValue (int) : valeur minimum possible (incluse)
            //      HighestValue (int) : valeur maximum possible (incluse)

            int Result;
            do
            {
                Console.Write(Message);
                bool IsNumber = int.TryParse(Console.ReadLine(), out Result);
                if (IsNumber && (Result < LowestValue || Result > HighestValue))
                    Console.WriteLine($"Merci d'entrer un nombre entre {LowestValue} et {HighestValue} !");
                else if (!IsNumber)
                    Console.WriteLine("Ceci n'est pas un nombre !");
            } while (Result < LowestValue || Result > HighestValue);

            return Result;

        }



        public static bool WriteFiles(
                    string FilePath,
                    string FileName,
                    List<Vehicle> VList,
                    int RaceLength,
                    List<Tuple<int, int>> RaceLog = null)
        {
            bool Success = true;

            try
            {
                // write podium file
                using StreamWriter MyStream = new StreamWriter(
                    Path.Combine(FilePath, FileName + ".csv"),
                    false,
                    Encoding.UTF8);
                {
                    // 1st line with race meta data
                    MyStream.WriteLine($"{VList.Count};{RaceLength / 1000}");

                    // for each car
                    foreach (Vehicle V in VList)
                    {
                        string DataToWrite =
                            $"{V.PodiumNumber};" +
                            $"{V.Brand};" +
                            $"{V.Model};" +
                            $"{V.Color};" +     // valeur numérique de l'énumération : (int)V.Color
                            $"{V.HorsePower}";

                        // write data to file
                        MyStream.WriteLine(DataToWrite);
                    }
                }

                // write log file
                using StreamWriter MyStreamLog = new StreamWriter(
                    Path.Combine(FilePath, FileName + ".log"),
                    false,
                    Encoding.UTF8);
                {
                    // 1st line with race meta data
                    MyStreamLog.WriteLine($"{VList.Count};{RaceLength / 1000}");

                    // for each car, write meta data
                    foreach (Vehicle V in VList)
                    {
                        string DataToWrite =
                            $"{V.UniqueNumberInRace};" +
                            $"{V.Brand};" +
                            $"{V.Model};" +
                            $"{V.Color};" +
                            $"{V.Image};" +
                            $"{V.HorsePower};" +
                            $"{V.PodiumNumber}";

                        // write data to file
                        MyStreamLog.WriteLine(DataToWrite);
                    }

                    // for each log
                    foreach (Tuple<int, int> Log in RaceLog)
                    {
                        string DataToWrite =
                            $"{Log.Item1};" +
                            $"{Log.Item2}";

                        // write data to file
                        MyStreamLog.WriteLine(DataToWrite);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"\n*** → Erreur lors de la sauvegarde du fichier {FileName}" +
                    $"\nMessage : {ex.Message}");
                Success = false;
            }

            if (Success)
                Console.WriteLine($"\nLe podium et le détail de la course ont été sauvegardés.");

            return Success;
        }

    }

}
