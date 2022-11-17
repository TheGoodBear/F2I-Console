using System.Reflection;

namespace CarRace3D
{
    public class Program
    {

        // global variables
        public static string FilePath =
            "C:\\Users\\FORMATEUR\\Documents\\F2I\\";
        //string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string FileName =
            "Track1.txt";
        const int ViewWidth = 100;
        const int ViewHeight = 40;
        const int TextLineOrigin = 2;
        static int TrackWidth = 60;
        static int TrackX = (ViewWidth - TrackWidth) / 2;
        static int RaceLength = 1000;
        const int TurnChance = 5;
        const int KeepTurningMinimum = 50;
        const int KeepTurningMaximum = 100;
        const int ChangeWidthChance = 3;
        const int KeepChangingWidthMinimum = 10;
        const int KeepChangingWidthMaximum = 40;
        const int MinimumWidth = 20;
        const int MaximumWidth = 60;

        static List<Tuple<int, int>> Track = new List<Tuple<int, int>>();
        static Random rnd = new Random();

        public static void Main()
        {

            InitializeTrack();
            Utilities.WriteFile(FilePath, FileName, Track);
            //StartProgram();

            //PrepareRace();
            //DrawTrack(NumberOfRacers, OriginY:TrackLineOrigin);
            //ShowRacers();
            //RaceInProgress();
            //RaceFinished();

            // fin du programme
            Console.SetCursorPosition(0, 32);
            Console.WriteLine("Entrée pour terminer.");
            Console.ReadLine();

        }


        private static void InitializeTrack()
        {
            int TurnRound = 0;
            int ChangeWidthRound = 0;
            int Step = 0;

            for (int i = 0; i <= RaceLength; i++)
            {
                Track.Add(new Tuple<int, int>(TrackX, TrackWidth));

                if (i >= RaceLength - 20)
                {
                    // don't change track near the end
                    TurnRound = 0;
                    ChangeWidthRound = 0;
                }

                if (TurnRound > 0)
                {
                    // turn
                    TurnRound--;
                    TrackX += Step;
                    if (TrackX < 1 || TrackX > ViewWidth - TrackWidth)
                    {
                        // view limit reached, stop turning
                        TrackX -= Step;
                        TurnRound = 0;
                    }
                }
                else if (ChangeWidthRound > 0)
                {
                    // change width
                    ChangeWidthRound--;
                    TrackWidth += Step;
                    TrackX -= Step;
                    if (TrackWidth < MinimumWidth || TrackWidth > MaximumWidth)
                    {
                        // width limit reached, stop changing width
                        TrackWidth -= Step;
                        ChangeWidthRound = 0;
                    }
                    if (TrackX < 1 || TrackX > ViewWidth - TrackWidth)
                    {
                        // view limit reached, stop changing width
                        TrackX += Step;
                        ChangeWidthRound = 0;
                    }
                }
                else
                {
                    Step = (rnd.Next(0, 2) == 0 ? -1 : 1);
                    if (rnd.Next(1, 101) <= TurnChance)
                    {
                        // start turning
                        TurnRound = rnd.Next(KeepTurningMinimum, KeepTurningMaximum + 1);
                    }
                    else if (rnd.Next(1, 101) <= ChangeWidthChance)
                    {
                        // start changing width
                        ChangeWidthRound = rnd.Next(KeepChangingWidthMinimum, KeepChangingWidthMaximum + 1);
                    }

                }

            }
        }

        private static void StartProgram()
        {
            // définir la vue
            Console.SetWindowSize(ViewWidth, ViewHeight);
            Console.CursorVisible = false;
            Console.Clear();

            // afficher les données de démarrage
            Console.WriteLine("Simulateur de véhicule 2D");

            Console.WriteLine("\nL'objectif est d'atteindre la ligne d'arrivée en un minimum de temps sans avoir d'accident.");
            Console.WriteLine("\nCommandes du véhicule :");
            Console.WriteLine($"Accélerer : (Z) ou (↑)");
            Console.WriteLine($"Ralentir : (X) ou (↓)");
            Console.WriteLine($"Tourner à gauche : (Q) ou (←)");
            Console.WriteLine($"Tourner à droite : (D) ou (→)");
            Console.WriteLine("\nEntrée pour démarrer la course...");
            Console.ReadLine();
        }

        //private static void PrepareRace()
        //{

        //    Console.WriteLine("\nPréparation de la course.");

        //    // demander le nombre de particiants
        //    NumberOfRacers = Utilities.AskNumber(
        //        $"\nEntrez un nombre de participants à la course (entre {MinimumNumberOfRacers} et {MaximumNumberOfRacers}) : ",
        //        MinimumNumberOfRacers,
        //        MaximumNumberOfRacers);

        //    // tirer les participants et ajouter à la liste Racers
        //    for (int Nb = 1; Nb <= NumberOfRacers; Nb++)
        //    {
        //        Vehicle Racer = Vehicles[rnd.Next(0, Vehicles.Count)];
        //        Racers.Add(new Vehicle(Racer));               
        //    }

        //    // demander la longueur de la course
        //    RaceLength = Utilities.AskNumber(
        //        $"\nEntrez une longueur de course (entre {MinimumRaceLength} et {MaximumRaceLength} km) : ",
        //        MinimumRaceLength,
        //        MaximumRaceLength) * 1000;

        //}

        //private static void ShowRacers(int Round = 0)
        //{
        //    string Message;
        //    if (Round > 0)
        //        Message = $"\nEtat de la course à la fin de l'étape {Round}{new string(' ', 50)}";
        //    else
        //        Message = $"\nListe des {Racers.Count} participants :{new string(' ', 50)}";

        //    Console.SetCursorPosition(0, TrackLineOrigin + Racers.Count + 2);
        //    Console.WriteLine(Message);
        //    foreach (Vehicle Racer in Racers)
        //    {
        //        Racer.DisplayData(Round > 0);
        //        Racer.Draw(RaceLength);
        //    }
        //}

        //private static void RaceInProgress()
        //{

        //    Console.SetCursorPosition(0, TrackLineOrigin + Racers.Count + 2);
        //    Console.WriteLine($"\nLes {Racers.Count} concurrents sont sur la ligne de départ... Entrée pour démarrer la course.");
        //    Console.ReadLine();

        //    int Round = 0;
        //    int ArrivedRacers = 0;
        //    while (ArrivedRacers < Racers.Count)
        //    {
        //        Round++;
        //        ShowRacers(Round);

        //        // move vehicles
        //        foreach (Vehicle Racer in Racers)
        //        {
        //            if (Racer.DistanceFromOrigin < RaceLength)
        //            {
        //                if (Racer.Move(rnd, SpeedRandomFactor, RaceLength))
        //                    ArrivedRacers++;
        //            }
        //        }

        //        // attendre le prochain tour
        //        //Console.SetCursorPosition(0, 32);
        //        //Console.ReadLine();
        //        Thread.Sleep(100);

        //    }

        //    // dernier affichage de tous les concurrents sur la ligne d'arrivée
        //    ShowRacers(Round);

        //}

        //private static void RaceFinished()
        //{
        //    Console.SetCursorPosition(0, TrackLineOrigin + Racers.Count + 2);

        //    Console.WriteLine("\nTous les véhicules ont franchi la ligne d'arrivée !");
        //    Console.WriteLine("Voici le podium :");

        //    // show podium (Racers sorted by PodiumNumber)
        //    Racers = Racers.OrderBy(v => v.PodiumNumber).ToList();
        //    foreach (Vehicle Racer in Racers)
        //    {
        //        Racer.DisplayData(true, true);
        //    }
        //}


        private static void DrawTrack(
            int NumberOfLines)
        {

            // dessin de la piste de course
            foreach (Tuple<int,int> TrackStep in Track)
            {
                
            }


            //Console.SetCursorPosition(OriginX, OriginY);
            //Console.Write(new String('■', 110));
            //for (int i = 1; i <= NumberOfLines; i++)
            //{
            //    Console.SetCursorPosition(OriginX, OriginY + i);
            //    Console.Write("    ░" + new String(' ', 100) + "░    ");
            //}
            //Console.SetCursorPosition(OriginX, OriginY + NumberOfLines + 1);
            //Console.Write(new String('■', 110));

        }
    }
}
