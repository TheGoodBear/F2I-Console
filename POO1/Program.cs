using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    public class Program
    {

        public static List<Vehicle> Vehicles = new List<Vehicle>();

        public static void Main()
        {
            //InitializeData();
            //ListVehicles();
            CreateWindow();
            
        }

        private static void InitializeData()
        {
            //Console.WriteLine("Salut");

            // instanciation d'un premier véhicule Car1
            Vehicle Car1 = new Vehicle(
                "Renault", "Clio", ConsoleColor.Blue, 7, Vehicle.eType.Berline, Vehicle.eEnergy.Essence);
            Vehicles.Add(Car1);

            // utilisation des propriétés de Car1
            //Console.WriteLine($"Mon premier véhicule Car1 est de couleur {Car1.Color}");
            //Car1.DisplayData();
            Car1.Color = ConsoleColor.Green;
            //Car1.DisplayData();
            //Console.WriteLine($"Mon premier véhicule Car1 est de couleur {Car1.Color}");

            Vehicle Car2 = new Vehicle();
            Vehicles.Add(Car2);
            //Car2.DisplayData();
            //Console.WriteLine($"Mon deuxième véhicule Car2 est de couleur {Car2.Color}");
            Car2.Brand = "Renault";
            Car2.Model = "Mégane";
            Car2.Color = ConsoleColor.Yellow;
            Car2.Type = Vehicle.eType.Berline;
            Car2.HorsePower = 60;
            //Car2.DisplayData();
            //Console.WriteLine($"Mon deuxième véhicule Car2 est de couleur {Car2.Color}");

            // Utilisation des méthodes de Car1
            Console.WriteLine($"Car1 a parcouru {Car1.Distance} mètres");
            Car1.Move();
            //Console.WriteLine($"Car1 a parcouru {Car1.Distance} mètres");
            Car1.Move(1000);
            Car1.Move(100);
            Car1.Move();

            //Console.WriteLine($"Car1 a parcouru {Car1.Distance} mètres");

            //// Utilisation d'une classe statique (non instanciable)
            //VehicleStatic.Color = "Rouge";
            //Console.WriteLine($"Véhicule statique a parcouru {VehicleStatic.Distance} mètres");
            //VehicleStatic.Move(1000);
            //Console.WriteLine($"Véhicule statique a parcouru {VehicleStatic.Distance} mètres");

            Vehicles.Add(new Vehicle
            {
                Brand = "Ferrari",
                Model = "Testarossa",
                Color = ConsoleColor.Red,
                Type = Vehicle.eType.Sport,
                Energy = Vehicle.eEnergy.Essence,
                HorsePower = 400
            });
            Vehicles.Add(new Vehicle(
                "Tesla",
                "Model S",
                ConsoleColor.Blue,
                250,
                Vehicle.eType.Berline,
                Vehicle.eEnergy.Electrique));
            Vehicles.Add(new Vehicle(
                "Volkswagen",
                "Touran",
                ConsoleColor.Red,
                80,
                Vehicle.eType.Monospace,
                Vehicle.eEnergy.Diesel));
        }

        private static void ListVehicles()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\nListe des {Vehicles.Count} véhicules");
            Console.ResetColor();
            foreach (Vehicle Vehicle in Vehicles)
            {
                Vehicle.DisplayData();
                Console.WriteLine(Vehicle);
            }
        }


        private static void CreateWindow()
        {
            Console.WindowWidth = 105;
            Console.WindowHeight = 30;

            Console.CursorVisible = false;

            for (int i = 1; i <= 100; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.CursorTop = 2;
                Console.CursorLeft = i;
                Console.Write(" ");

                if (i % 10 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorTop = 4;
                    Console.CursorLeft = i;
                    Console.Write(i.ToString());
                }

                Thread.Sleep(100);
            }

            Console.ResetColor();
            Console.CursorTop = 10;

        }
    }
}
