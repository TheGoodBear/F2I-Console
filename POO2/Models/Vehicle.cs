using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Models
{
    internal class Vehicle
    {

        static int NextID = 0;

        public int ID { get; set; } 
        public string Name { get; set; }
        public int Distance { get; set; } = 0;



        public Vehicle(
            string Name)
        {
            NextID++;
            this.ID = NextID;
            this.Name = Name;
        }


        public override string ToString()
        {
            return $"({ID}) {Name} a parcouru {Distance}km";
        }


        public void Move(int Distance)
        {
            this.Distance += Distance;
        }

    }

}
