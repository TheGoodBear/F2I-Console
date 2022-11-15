using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    public static class VehicleStatic
    {
        // Modèle (classe intanciable) Vehicle

        #region "Properties"
        // Propriétés de la classe Vehicle
        public static string Brand { get; set; }
        public static string Model { get; set; }
        public static string Color { get; set; }

        public static int Distance { get; set; }
        #endregion

        #region "Methods"
        // Méthodes de la classe Vehicle

        #region "Constructors"
        // Constructeurs interdits dans une classe statique
        #endregion

        public static void Move(
            int DistanceToMove = 1)
        {
            Distance += DistanceToMove;
        }

        #endregion

    }

}
