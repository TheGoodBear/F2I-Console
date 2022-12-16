using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using CarRace2D.Code_files;
using CarRace2D.Models;
using CarRace2D.Code_files;

namespace CarRace2D;

public class Program
{

    // global variables
    static string AssemblyPath =
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    static string FilePath = Path.Combine(AssemblyPath, "Tracks");
    public static string FileName =
        "Track-<>.txt";


    public static void Main()
    {
        //Test();

        StartProgram();
        
        Game.PrepareRace();

        Game.Loop();

        EndProgram();

    }

    private static void StartProgram()
    {
        // définir la vue
        View.Initialize();

        // afficher les données de démarrage
        Console.WriteLine("Simulateur de véhicule 2D");

        Console.WriteLine("\nL'objectif est d'atteindre la ligne d'arrivée en un minimum de temps sans avoir d'accident.");
        Console.WriteLine("\nCommandes du véhicule :");
        Console.WriteLine($"Accélerer : (Z) ou (▲)");
        Console.WriteLine($"Ralentir : (X) ou (▼)");
        Console.WriteLine($"Tourner à gauche : (Q) ou (◄)");
        Console.WriteLine($"Tourner à droite : (D) ou (►)");
        Console.WriteLine("\nEntrée pour démarrer la course...");
        Console.ReadLine();

        Console.Clear();
    }


    private static void EndProgram()
    {

        // fin du programme
        Console.ResetColor();
        Console.SetCursorPosition(30, 40);
        Console.WriteLine("Entrée pour terminer.");
        Console.ReadLine();
    }

    static void Test()
        {
            Console.Clear();

            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            Console.Write("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");

            char? first = Utilities.GetCharacterAt(10, 1);
            char? second = Utilities.GetCharacterAt(20, 1);

        Console.WriteLine($"\n{first} - {second}");

        Console.ReadLine();
        }


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


    //private static void CreateTrackOnce(
    //    int? MaxRounds = MaxRounds)
    //{
    //    int TurnRound = 0;
    //    int ChangeWidthRound = 0;
    //    int Step = 0;

    //    for (int i = 0; i < MaxRounds; i++)
    //    {
    //        Track.Add(new Tuple<int, int>(TrackX, TrackWidth));

    //        if (i >= MaxRounds - 20)
    //        {
    //            // don't change track near the end
    //            TurnRound = 0;
    //            ChangeWidthRound = 0;
    //        }

    //        if (TurnRound > 0)
    //        {
    //            // turn
    //            TurnRound--;
    //            TrackX += Step;
    //            if (TrackX < 1 || TrackX > ViewWidth - TrackWidth)
    //            {
    //                // view limit reached, stop turning
    //                TrackX -= Step;
    //                TurnRound = 0;
    //            }
    //        }
    //        else if (ChangeWidthRound > 0)
    //        {
    //            // change width
    //            ChangeWidthRound--;
    //            TrackWidth += Step;
    //            TrackX -= Step;
    //            if (TrackWidth < MinimumWidth || TrackWidth > MaximumWidth)
    //            {
    //                // width limit reached, stop changing width
    //                TrackWidth -= Step;
    //                ChangeWidthRound = 0;
    //            }
    //            if (TrackX < 1 || TrackX > ViewWidth - TrackWidth)
    //            {
    //                // view limit reached, stop changing width
    //                TrackX += Step;
    //                ChangeWidthRound = 0;
    //            }
    //        }
    //        else
    //        {
    //            Step = (rnd.Next(0, 2) == 0 ? -1 : 1);
    //            if (rnd.Next(1, 101) <= TurnChance)
    //            {
    //                // start turning
    //                TurnRound = rnd.Next(KeepTurningMinimum, KeepTurningMaximum + 1);
    //            }
    //            else if (rnd.Next(1, 101) <= ChangeWidthChance)
    //            {
    //                // start changing width
    //                ChangeWidthRound = rnd.Next(KeepChangingWidthMinimum, KeepChangingWidthMaximum + 1);
    //            }

    //        }

    //    }

    //    // save track
    //    if (MaxRounds != null)
    //        Utilities.WriteFile(FilePath, FileName, Track);
    //}


    //private static void DrawTrackOnce()
    //{

    //    int Distance = 0;

    //    // dessin de la piste de course
    //    foreach (Tuple<int, int> TrackStep in Track)
    //    {
    //        Distance++;
    //        Console.SetCursorPosition(ViewWidth / 2, HUDLineOrigin);
    //        Console.Write($"{Distance} / {MaxRounds}");

    //        Console.MoveBufferArea(
    //            0, TrackStartLine,
    //            ViewWidth + 10, TrackMaxLines - 1,
    //            0, TrackStartLine + 1);

    //        Console.SetCursorPosition(TrackStep.Item1, TrackStartLine);
    //        Console.Write(TrackBorder);
    //        Console.SetCursorPosition(TrackStep.Item1 + TrackStep.Item2, TrackStartLine);
    //        Console.Write(TrackBorder);

    //        //Console.WriteLine(
    //        //    new string(' ', TrackStep.Item1)
    //        //    + TrackBorder
    //        //    + new string(' ', TrackStep.Item2)
    //        //    + TrackBorder);

    //        Thread.Sleep(10);

    //    }

    //}

}
