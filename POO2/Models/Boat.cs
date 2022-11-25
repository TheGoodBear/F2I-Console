using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Models
{
    internal class Boat : Vehicle
    {

        public int NumberOfScrews { get; set; }


        public Boat(
            string Name,
            int NumberOfScrews
            ) : base(Name)
        {

            this.NumberOfScrews = NumberOfScrews;

        }

        public override string ToString()
        {
            return $"{base.ToString()} ({NumberOfScrews} hélices)";
        }

    }

}
