using POO2.Models;
using System.Xml.Linq;

namespace POO2;

class Program
{

    static Vehicle MyVehicle = null;
    static Plane MyPlane = null;
    static Boat MyBoat = null;
    static List<Vehicle> Vehicles = new List<Vehicle>();

    static void Main()
    {
        InititializeData();
        DisplayList(Vehicles);

        MyVehicle = GetVehicle(2);
        MyVehicle.Move(200);
        MyPlane = (Plane)GetVehicle(5);
        MyPlane.Move(3000);
        MyPlane.ChangeAltitude(1000);
        DisplayList(Vehicles);
    }


    private static void InititializeData()
    {
        Vehicles.Add(new Vehicle("Mercedes"));
        Vehicles.Add(new Boat("Le Triton", 2));
        Vehicles.Add(new Plane("B340", 2));
        Vehicles.Add(new Vehicle("Dacia"));
        Vehicles.Add(new Plane("B747", 4));
    }


    private static Vehicle GetVehicle(int ID)
    {
        return Vehicles.First(e => e.ID == ID);
    }


    private static void DisplayList(
        List<Vehicle> Elements)
    {
        Console.WriteLine("\nListe des véhicules :");
        foreach (Vehicle Element in Elements)
        {
            Console.WriteLine(Element);
        }
    }

}