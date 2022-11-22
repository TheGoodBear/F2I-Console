using System;
using System.IO.Enumeration;
using System.Reflection;
using System.Text;

namespace CarRaceV4
{
    public class Program
    {

        // global variables
        const int ViewWidth = 110;
        const int ViewHeight = 35;
        const int TrackLineOrigin = 6;

        // AssemblyPath = root du fichier exécutable
        // (dossier calculé dynamiquement au lancement du programme)
        static string AssemblyPath = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location);
        //static string FilePath = AssemblyPath + "\\Save\\";
        static string FilePath = Path.Combine(AssemblyPath, "Save");


        const int MinimumNumberOfRacers = 2;
        const int MaximumNumberOfRacers = 10;
        static int NumberOfRacers = 0;
        const int MinimumRaceLength = 10;
        const int MaximumRaceLength = 100;
        static int RaceLength = 0;
        const int SpeedRandomFactor = 10;
        static List<Vehicle> Vehicles = new List<Vehicle>();
        static List<Vehicle> Racers = new List<Vehicle>();
        static List<Tuple<int, int>> RaceLog = new List<Tuple<int, int>>();
        static Random rnd = new Random();

        public static void Main()
        {

            InitializeContext();
            InitializeData();
            StartProgram();

            bool StopProgram = false;
            while (!StopProgram)
                StopProgram = MainMenu();

            // fin du programme
            Console.SetCursorPosition(0, 32);
            Console.WriteLine("Entrée pour terminer.");
            Console.ReadLine();

        }

        private static void InitializeContext()
        {
            // création du dossier de sauvegarde des fichiers s'il n'existe pas
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
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

        private static bool MainMenu()
        {
            bool StopProgram = false;

            Console.WriteLine("\nQue souhaites-tu faire ?");
            Console.WriteLine("1 - Lancer une nouvelle course");
            Console.WriteLine("2 - Voir l'historique des courses");
            Console.WriteLine("3 - Rejouer une course");
            Console.WriteLine("0 - Quitter le programme");

            int UserChoice = Utilities.AskNumber(
                "Fais ton choix : ",
                HighestValue: 3);

            if (UserChoice == 1)
            {
                PrepareRace();
                DrawTrack(NumberOfRacers, OriginY: TrackLineOrigin);
                ShowRacers();
                RaceInProgress();
                RaceFinished();
            }
            else if (UserChoice == 2)
            {
                ViewHistory(GetOldRaces());
            }
            else if (UserChoice == 3)
            {
                ReplayRace(GetOldRaces(true));
                RaceFinished(false);
            }
            else if (UserChoice == 0)
            {
                StopProgram = true;
            }

            return StopProgram;
        }

        private static void PrepareRace()
        {

            Console.Clear();
            Console.WriteLine("\nPréparation de la course.");

            // demander le nombre de particiants
            NumberOfRacers = Utilities.AskNumber(
                $"\nEntrez un nombre de participants à la course (entre {MinimumNumberOfRacers} et {MaximumNumberOfRacers}) : ",
                MinimumNumberOfRacers,
                MaximumNumberOfRacers);

            // tirer les participants et ajouter à la liste Racers
            Racers.Clear();
            Vehicle.UniqueNumber = 0;
            Vehicle.NextPodiumNumber = 0;

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

            // ajouter chaque véhicule au départ dans le log
            foreach (Vehicle Racer in Racers)
            {
                RaceLog.Add(new Tuple<int, int>(Racer.UniqueNumberInRace, 0));
            }

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

                    // ajoute les informations de chaque véhicule dans le log
                    RaceLog.Add(new Tuple<int, int>(Racer.UniqueNumberInRace, Racer.DistanceFromOrigin));
                }

                // attendre le prochain tour
                //Console.SetCursorPosition(0, 32);
                //Console.ReadLine();
                Thread.Sleep(100);

            }

            // dernier affichage de tous les concurrents sur la ligne d'arrivée
            ShowRacers(Round);

        }

        private static void RaceFinished(
            bool SaveData = true)
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

            if (SaveData)
            {
                // save podium and log to files in Save folder
                string FileName = $"Race-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                Utilities.WriteFiles(FilePath, FileName, Racers, RaceLength, RaceLog);
            }

        }


        private static Tuple<string[], int> GetOldRaces(
            bool Replay = false)
        {
            string FileExtension = (Replay ? "*.log" : "*.csv");

            // get old races file list
            string[] OldRaces = Directory
                .GetFiles(FilePath, FileExtension)
                .OrderByDescending(s => Path.GetFileName(s))
                .ToArray();

            if (OldRaces.Length == 0)
            {
                Console.WriteLine("\nIl n'y a aucune course à voir.");
                Console.WriteLine("\nEntrée pour revenir au menu");
                Console.ReadLine();
                return null;
            }

            Console.Clear();
            Console.WriteLine("\nListe des courses sauvegardées :");
            int FileNumber = 1;
            foreach (string OldRace in OldRaces)
            {
                string OldRaceName = Path.GetFileName(OldRace);

                // read file meta data
                string[] MetaDataList;
                using StreamReader MyStream1 = new StreamReader(OldRace, Encoding.UTF8);
                {
                    string MetaData = MyStream1.ReadLine();
                    MetaDataList = MetaData.Split(";");
                };

                Console.WriteLine($"{FileNumber} - Course de {MetaDataList[1]}km avec {MetaDataList[0]} participants");
                FileNumber++;
            }

            // ask user choosen race
            int UserChoice = Utilities.AskNumber(
                "Numéro de la course à visualiser : ",
                1,
                OldRaces.Length);

            // return race number
            return new Tuple<string[], int>(OldRaces, UserChoice);

        }

        private static void ViewHistory(
            Tuple<string[], int> RaceFile)
        {

            // show race details
            using StreamReader MyStream = new StreamReader(
                RaceFile.Item1[RaceFile.Item2 - 1], Encoding.UTF8);
            {
                string[] MetaDataList = MyStream.ReadLine().Split(";");
                Console.WriteLine($"\nDétails de la course de {MetaDataList[1]}km avec {MetaDataList[0]} participants");

                string Racer = MyStream.ReadLine();
                while (Racer != null)
                {
                    string[] RacerData = Racer.Split(";");
                    Console.ForegroundColor =
                        (ConsoleColor)Enum.Parse(
                            typeof(ConsoleColor),
                            RacerData[3]);
                    //Console.ForegroundColor = (ConsoleColor)Convert.ToInt32(RacerData[3]);

                    Console.WriteLine($"{RacerData[0]} → {RacerData[1]} {RacerData[2]} de {RacerData[4]}cv");
                    Racer = MyStream.ReadLine();
                }
            };

            Console.ResetColor();
            Console.WriteLine("\nEntrée pour revenir au menu");
            Console.ReadLine();

        }

        private static void ReplayRace(
            Tuple<string[], int> RaceFile)
        {

            // get race data from file
            using StreamReader MyStream = new StreamReader(
                RaceFile.Item1[RaceFile.Item2 - 1], Encoding.UTF8);
            {
                // read race meta data
                string[] MetaDataList = MyStream.ReadLine().Split(";");
                NumberOfRacers = Convert.ToInt32(MetaDataList[0]);
                RaceLength = Convert.ToInt32(MetaDataList[1]) * 1000;
                Console.WriteLine($"\nReplay de la course de {RaceLength / 1000}km avec {NumberOfRacers} participants");

                // read racers meta data
                Racers.Clear();
                for (int i = 1; i <= Convert.ToInt32(MetaDataList[0]); i++)
                {
                    string Racer = MyStream.ReadLine();
                    string[] RacerData = Racer.Split(";");
                    Racers.Add(new Vehicle(
                        RacerData[1],
                        RacerData[2],
                        (ConsoleColor)Enum.Parse(typeof(ConsoleColor), RacerData[3]),
                        Convert.ToInt32(RacerData[5]),
                        Convert.ToInt32(RacerData[0]),
                        RacerData[4]));
                }

                // read race log
                RaceLog.Clear();
                string Log = MyStream.ReadLine();
                while (Log != null)
                {
                    string[] LogData = Log.Split(";");
                    RaceLog.Add(new Tuple<int, int>(Convert.ToInt32(LogData[0]), Convert.ToInt32(LogData[1])));
                    Log = MyStream.ReadLine();
                }

            };

            Console.Clear();
            Console.CursorVisible = false;
            DrawTrack(NumberOfRacers, OriginY: TrackLineOrigin);
            Vehicle.NextPodiumNumber = 0;
            Vehicle.UniqueNumber = Racers.Count;

            Console.SetCursorPosition(0, TrackLineOrigin + Racers.Count + 2);
            Console.WriteLine($"\nLes {Racers.Count} concurrents sont sur la ligne de départ... Entrée pour démarrer la course.");
            ShowRacers(0);
            Console.ReadLine();

            int RoundNumber = 0;
            int LogNumber = 0;
            foreach (Tuple<int, int> LogData in RaceLog)
            {

                // move vehicles
                Vehicle CurrentRacer = Racers.First
                    (r => r.UniqueNumberInRace == LogData.Item1);
                CurrentRacer.DistanceFromOrigin = LogData.Item2;

                if (CurrentRacer.DistanceFromOrigin >= RaceLength
                    && CurrentRacer.PodiumNumber == 0)
                {
                    Vehicle.NextPodiumNumber++;
                    CurrentRacer.PodiumNumber = Vehicle.NextPodiumNumber;
                }

                LogNumber++;
                if (LogNumber % Racers.Count == 0)
                {
                    ShowRacers(RoundNumber);
                    RoundNumber++;
                    // attendre le prochain tour
                    Thread.Sleep(100);

                }

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
