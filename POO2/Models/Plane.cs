using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Models
{
    internal class Plane : Vehicle
    {

        public int NumberOfReactors { get; set; }
        public int Altitude { get; set; } = 0;


        public Plane(
            string Name,
            int NumberOfReactors
            ) : base(Name)
        {

            this.NumberOfReactors = NumberOfReactors;

        }

        public override string ToString()
        {
            return $"{base.ToString()} et se trouve à {Altitude} pieds ({NumberOfReactors} réacteurs)";
        }


        public void ChangeAltitude(
            int Altitude)
        {
            this.Altitude += Altitude;

            if (this.Altitude < 0)
                Console.WriteLine("CRASH !");

        }

    }

}
