using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    public class Vehicle
    {

        #region "Global variables"

        private static int UniqueNumber = 0;
        private static int NextPodiumNumber = 0;

        #endregion

        #region "Properties"

        public string Brand { get; set; }
        public string Model { get; set; }
        public ConsoleColor Color { get; set; }
        public int HorsePower { get; set; }
        public int DistanceFromOrigin { get; set; } = 0;
        public int? UniqueNumberInRace { get; set; } = null;
        public int? PodiumNumber { get; set; } = null;

        #endregion

        #region "Methods"

        // constructor
        public Vehicle(
            string Brand,
            string Model,
            ConsoleColor Color,
            int HorsePower)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Color = Color;
            this.HorsePower = HorsePower;
        }
        public Vehicle(
            Vehicle InitialVehicle)
        {
            this.Brand = InitialVehicle.Brand;
            this.Model = InitialVehicle.Model;
            this.Color = InitialVehicle.Color;
            this.HorsePower = InitialVehicle.HorsePower;
            UniqueNumber++;
            this.UniqueNumberInRace = UniqueNumber;
        }

        public void DisplayData(
            bool ShowDistance = true,
            bool ShowPodiumNumber = false)
        {
            string DisplayString = $"Voiture numéro {UniqueNumberInRace} - {Brand} {Model} ({HorsePower}cv)";
            if (PodiumNumber == null)
            {
                // vehicle still in race
                Console.ForegroundColor = Color;

                if (ShowDistance)
                    DisplayString += $" a parcourue {DistanceFromOrigin / 1000}km";
            }
            else
            {
                // vehicle has arrived
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = Color;
                DisplayString += " est arrivée !!!";
            }

            if (ShowPodiumNumber)
                DisplayString = $"{PodiumNumber} → " + DisplayString;

            Console.Write(DisplayString);
            Console.ResetColor();
            Console.Write("\n");
        }

        public bool Move(
            Random rnd, 
            int RandomFactor, 
            int RaceLength)
        {

            // random factor is a %
            int RandomDistance = HorsePower * RandomFactor / 100;

            int RandomStep = rnd.Next(0, 2);
            int RandomMultiplicator = (RandomStep == 0 ? -1 : 1);
            //int RandomMultiplicator;
            //if (RandomStep == 0)
            //    RandomMultiplicator = -1;
            //else
            //    RandomMultiplicator = 1;

            DistanceFromOrigin += HorsePower + RandomMultiplicator * RandomDistance;

            // check if vehicle has arrived
            if (DistanceFromOrigin >= RaceLength)
            {
                NextPodiumNumber++;
                PodiumNumber = NextPodiumNumber;
            }

            return (PodiumNumber > 0);
        }

        #endregion

    }
}
