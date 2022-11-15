using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    public class Vehicle
    {
        // Modèle (classe intanciable) Vehicle

        #region "Enumerations"
        public enum eType
        {
            Berline,
            Monospace,
            Sport,
            Compacte
        }
        public enum eEnergy
        {
            Electrique,
            Essence,
            Diesel
        }
        #endregion

        #region "Properties"
        // Propriétés de la classe Vehicle
        public string Brand { get; set; }
        public string Model { get; set; }
        public ConsoleColor Color { get; set; }
        public int HorsePower { get; set; }
        public eType Type { get; set; }
        public eEnergy Energy { get; set; }

        public int Distance { get; set; }

        #endregion

        #region "Methods"
        // Méthodes de la classe Vehicle

        #region "Constructors"
        public Vehicle()
        {

        }
        public Vehicle(
            string Brand,
            string Model,
            ConsoleColor Color,
            int HorsePower,
            eType Type,
            eEnergy Energy)
        {
            // Constructeur de la classe Vehicle

            this.Brand = Brand;
            this.Model = Model;
            this.Color = Color;
            this.HorsePower = HorsePower;
            this.Type = Type;
            this.Energy = Energy;
        }
        #endregion

        public void DisplayData()
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine($"La {this.Brand} {this.Model} est de couleur {this.Color}");
            Console.ResetColor();
        }
        public void Move(
            int DistanceToMove = 1)
        {
            this.Distance += DistanceToMove;
        }

        public override string ToString()
        {
            string VehiculeString = 
                $"{this.Brand} {this.Model} {this.Type} {this.Color} {this.HorsePower}cv";
            return VehiculeString;
        }

        #endregion

    }

}
