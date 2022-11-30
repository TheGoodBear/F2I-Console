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



    }

}
