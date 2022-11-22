namespace CarRaceV4
{
    public class Vehicle
    {

        #region "Global variables"

        public static int UniqueNumber = 0;
        public static int NextPodiumNumber = 0;
        private static int StartX = 0;
        private static int StartY = 6;

        #endregion

        #region "Properties"

        public string Brand { get; set; }
        public string Model { get; set; }
        public ConsoleColor Color { get; set; }
        public int HorsePower { get; set; }
        public int DistanceFromOrigin { get; set; } = 0;
        public int UniqueNumberInRace { get; set; } = 0;
        public int PodiumNumber { get; set; } = 0;
        public string Image { get; set; } = "|  ►";

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
            string Number = (UniqueNumberInRace < 10 ? $"={UniqueNumberInRace}" : $"{UniqueNumberInRace}");
            this.Image = Image.Replace("  ", Number);
        }

        public void DisplayData(
            bool ShowDistance = true,
            bool ShowPodiumNumber = false)
        {
            string DisplayString = $"Voiture numéro {UniqueNumberInRace} - {Brand} {Model} ({HorsePower}cv)";
            int DisplayLine = StartY + UniqueNumber + UniqueNumberInRace + 4;

            if (PodiumNumber == 0)
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
                DisplayLine = StartY + UniqueNumber + PodiumNumber + 4;
            }

            if (ShowPodiumNumber)
                DisplayString = $"{PodiumNumber} → " + DisplayString;

            Console.SetCursorPosition(StartX, DisplayLine);
            Console.Write(DisplayString + new string(' ', 10));
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
                DistanceFromOrigin = RaceLength;   
                NextPodiumNumber++;
                PodiumNumber = NextPodiumNumber;
            }

            return (PodiumNumber > 0);
        }


        public void Draw(int RaceLength)
        {
            int PositionOnTrack = (DistanceFromOrigin * 100) / RaceLength;
            Console.SetCursorPosition(StartX, StartY + UniqueNumberInRace);
            //Console.SetCursorPosition(StartX + PositionOnTrack, StartY + UniqueNumberInRace);
            Console.ForegroundColor = Color;
            Console.Write($"{new string(' ', PositionOnTrack)}{Image}");
            Console.ResetColor();
        }

        #endregion

    }
}
