namespace CarRaceV2
{
    public class Program
    {

        // global variables
        const int ViewWidth = 110;
        const int ViewHeight = 35;
        const int TrackLineOrigin = 6;

        const int MinimumNumberOfRacers = 2;
        const int MaximumNumberOfRacers = 10;
        static int NumberOfRacers = 0;
        const int MinimumRaceLength = 10;
        const int MaximumRaceLength = 100;
        static int RaceLength = 0;
        const int SpeedRandomFactor = 10;
        static List<Vehicle> Vehicles = new List<Vehicle>();
        static List<Vehicle> Racers = new List<Vehicle>();
        static Random rnd = new Random();

        public static void Main()
        {

            InitializeData();
            StartProgram();
            PrepareRace();
            DrawTrack(NumberOfRacers, OriginY:TrackLineOrigin);
            ShowRacers();
            RaceInProgress();
            RaceFinished();

            // fin du programme
            Console.SetCursorPosition(0, 32);
            Console.WriteLine("Entrée pour terminer.");
            Console.ReadLine();

        }


        private static void InitializeData()
        {
            Vehicles.Add(new Vehicle("Bentley", "Luxe", ConsoleColor.Gray, 200));
            Vehicles.Add(new Vehicle("Ferrari", "Testarrossa", ConsoleColor.Red, 300));
            Vehicles.Add(new Vehicle("Lamborghini", "Countach", ConsoleColor.Yellow, 280));
            Vehicles.Add(new Vehicle("Ferrari", "F40", ConsoleColor.Magenta, 330));
            Vehicles.Add(new Vehicle("Tesla", "Model S", ConsoleColor.Blue, 200));
            Vehicles.Add(new Vehicle("Porsche", "911 Carrera GT", ConsoleColor.Green, 250));
            Vehicles.Add(new Vehicle("BMW", "M3", ConsoleColor.DarkBlue, 230));
            Vehicles.Add(new Vehicle("Ford", "GT 40", ConsoleColor.Red, 240));
            Vehicles.Add(new Vehicle("Lada", "Minabilis", ConsoleColor.White, 190));
            Vehicles.Add(new Vehicle("Peugeot", "208 GT", ConsoleColor.Cyan, 180));
            Vehicles.Add(new Vehicle("Bugatti", "Chiron", ConsoleColor.DarkYellow, 260));
            Vehicles.Add(new Vehicle("Mercedes", "AMG", ConsoleColor.DarkMagenta, 240));
        }

        private static void StartProgram()
        {
            // définir la vue
            Console.SetWindowSize(ViewWidth, ViewHeight);

            // afficher les données de démarrage
            Console.WriteLine("Simulateur de course de voitures");

            Console.WriteLine("\nL'objectif est de faire courrir 2 à 10 voitures parmi une liste de véhicules possibles.");
            Console.WriteLine("A chaque tour, tous les véhicules avancent d'une distance aléatoire en relation avec leur puissance.");
            Console.WriteLine("Lorsque tous les véhicules ont franchis la ligne d'arrivée, on affiche le podium et on termine le programme.");
        }

        private static void PrepareRace()
        {

            Console.WriteLine("\nPréparation de la course.");

            // demander le nombre de particiants
            NumberOfRacers = Utilities.AskNumber(
                $"\nEntrez un nombre de participants à la course (entre {MinimumNumberOfRacers} et {MaximumNumberOfRacers}) : ",
                MinimumNumberOfRacers,
                MaximumNumberOfRacers);
        
            // tirer les participants et ajouter à la liste Racers
            for (int Nb = 1; Nb <= NumberOfRacers; Nb++)
            {
                Vehicle Racer = Vehicles[rnd.Next(0, Vehicles.Count)];
                Racers.Add(new Vehicle(Racer));               
            }

            // demander la longueur de la course
            RaceLength = Utilities.AskNumber(
                $"\nEntrez une longueur de course (entre {MinimumRaceLength} et {MaximumRaceLength} km) : ",
                MinimumRaceLength,
                MaximumRaceLength) * 1000;

        }

        private static void ShowRacers(int Round = 0)
        {
            string Message;
            if (Round > 0)
                Message = $"\nEtat de la course à la fin de l'étape {Round}{new string(' ', 50)}";
            else
                Message = $"\nListe des {Racers.Count} participants :{new string(' ', 50)}";

            Console.SetCursorPosition(0, TrackLineOrigin + Racers.Count + 2);
            Console.WriteLine(Message);
            foreach (Vehicle Racer in Racers)
            {
                Racer.DisplayData(Round > 0);
                Racer.Draw(RaceLength);
            }
        }

        private static void RaceInProgress()
        {

            Console.SetCursorPosition(0, TrackLineOrigin + Racers.Count + 2);
            Console.WriteLine($"\nLes {Racers.Count} concurrents sont sur la ligne de départ... Entrée pour démarrer la course.");
            Console.ReadLine();

            int Round = 0;
            int ArrivedRacers = 0;
            while (ArrivedRacers < Racers.Count)
            {
                Round++;
                ShowRacers(Round);

                // move vehicles
                foreach (Vehicle Racer in Racers)
                {
                    if (Racer.DistanceFromOrigin < RaceLength)
                    {
                        if (Racer.Move(rnd, SpeedRandomFactor, RaceLength))
                            ArrivedRacers++;
                    }
                }

                // attendre le prochain tour
                //Console.SetCursorPosition(0, 32);
                //Console.ReadLine();
                Thread.Sleep(100);

            }

            // dernier affichage de tous les concurrents sur la ligne d'arrivée
            ShowRacers(Round);

        }

        private static void RaceFinished()
        {
            Console.SetCursorPosition(0, TrackLineOrigin + Racers.Count + 2);

            Console.WriteLine("\nTous les véhicules ont franchi la ligne d'arrivée !");
            Console.WriteLine("Voici le podium :");

            // show podium (Racers sorted by PodiumNumber)
            Racers = Racers.OrderBy(v => v.PodiumNumber).ToList();
            foreach (Vehicle Racer in Racers)
            {
                Racer.DisplayData(true, true);
            }
        }


        private static void DrawTrack(
            int NumberOfLines,
            int OriginX = 0,
            int OriginY = 0)
        {
            Console.Clear();
            StartProgram();

            // dessin de la piste de course
            Console.SetCursorPosition(OriginX, OriginY);
            Console.Write(new String('■', 110));
            for (int i = 1; i <= NumberOfLines; i++)
            {
                Console.SetCursorPosition(OriginX, OriginY + i);
                Console.Write("    ░" + new String(' ', 100) + "░    ");
            }
            Console.SetCursorPosition(OriginX, OriginY + NumberOfLines + 1);
            Console.Write(new String('■', 110));

        }
    }
}
 