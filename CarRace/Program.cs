using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    public class Program
    {

        // global variables
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
            ShowRacers();
            RaceInProgress();
            RaceFinished();

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
            Console.WriteLine("Simulateur de course de voitures");

            Console.WriteLine("\nL'objectif est de faire courrir 2 à 10 voitures parmi une liste de véhicules possibles.");
            Console.WriteLine("A chaque tour, tous les véhicules avancent d'une distance aléatoire en relation avec leur puissance.");
            Console.WriteLine("Lorsque tous les véhicules ont franchis la ligne d'arrivée, on affiche le podium et on termine le programme.");
        }

        private static void PrepareRace()
        {

            Console.WriteLine("\nPréparation de la course.");

            // demander le nombre de particiants
            NumberOfRacers = 0;
            do
            {
                Console.Write($"\nEntrez un nombre de participants à la course (entre {MinimumNumberOfRacers} et {MaximumNumberOfRacers}) : ");
                bool IsNumber = int.TryParse(Console.ReadLine(), out NumberOfRacers);
                if (IsNumber && (NumberOfRacers < MinimumNumberOfRacers || NumberOfRacers > MaximumNumberOfRacers))
                    Console.WriteLine($"Merci d'entrer un nombre entre {MinimumNumberOfRacers} et {MaximumNumberOfRacers} !");
                else if (!IsNumber)
                    Console.WriteLine("Ceci n'est pas un nombre !"); 
            } while (NumberOfRacers < MinimumNumberOfRacers || NumberOfRacers > MaximumNumberOfRacers);
        
            // tirer les participants et ajouter à la liste Racers
            for (int Nb = 1; Nb <= NumberOfRacers; Nb++)
            {
                Vehicle Racer = Vehicles[rnd.Next(0, Vehicles.Count)];
                Racers.Add(new Vehicle(Racer));               
            }

            // demander la longueur de la course
            RaceLength = 0;
            do
            {
                Console.Write($"\nEntrez une longueur de course (entre {MinimumRaceLength} et {MaximumRaceLength}) : ");
                bool IsNumber = int.TryParse(Console.ReadLine(), out RaceLength);
                if (IsNumber && (RaceLength < MinimumRaceLength || RaceLength > MaximumRaceLength))
                    Console.WriteLine($"Merci d'entrer un nombre entre {MinimumRaceLength} et {MaximumRaceLength} !");
                else if (!IsNumber)
                    Console.WriteLine("Ceci n'est pas un nombre !");
            } while (RaceLength < MinimumRaceLength || RaceLength > MaximumRaceLength);
            RaceLength *= 1000;

        }

        private static void ShowRacers(int Round = 0)
        {
            string Message;
            if (Round > 0)
                Message = $"\nEtat de la course à la fin de l'étape {Round}";
            else
                Message = $"\nListe des {Racers.Count} participants :";

            Console.WriteLine(Message);
            foreach (Vehicle Racer in Racers)
            {
                Racer.DisplayData(Round > 0);
            }
        }

        private static void RaceInProgress()
        {
            Console.WriteLine($"\nLes {Racers.Count} concurrents sont sur la ligne de départ...");

            int Round = 0;
            int ArrivedRacers = 0;
            do
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

            } while (ArrivedRacers < Racers.Count);
        }

        private static void RaceFinished()
        {
            Console.WriteLine("\nTous les véhicules ont franchi la ligne d'arrivée !");
            Console.WriteLine("Voici le podium :");

            // show podium (Racers sorted by PodiumNumber)
            Racers = Racers.OrderBy(v => v.PodiumNumber).ToList();
            foreach (Vehicle Racer in Racers)
            {
                Racer.DisplayData(true, true);
            }
        }

    }
}
