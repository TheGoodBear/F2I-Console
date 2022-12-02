using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace2D.Models;

internal static class Track
{

    static Random rnd = new Random();

    internal static List<Tuple<int, int>> Data = new List<Tuple<int, int>>();

    internal static int Width = 60;
    internal static int X = (View.Width - Width) / 2;
    const string BorderStyle = "▓";
    internal const string StartLineStyle = "░";
    internal const int StartY = 3;
    internal const int LineStartY = 5;
    internal static int Height = 30;

    const int TurnChance = 5;
    const int KeepTurningMinimum = 50;
    const int KeepTurningMaximum = 100;
    const int ChangeWidthChance = 3;
    const int KeepChangingWidthMinimum = 10;
    const int KeepChangingWidthMaximum = 40;
    const int MinimumWidth = 20;
    const int MaximumWidth = 60;


    internal static void Create()
    {
        // Round parameters:
        //  1 - TurnRound
        //  2 - ChangeWidthRound

        int Round = Game.CurrentRound;
        int TurnRound = Game.RoundParameters.Item1;
        int ChangeWidthRound = Game.RoundParameters.Item2;
        int Step = 0;

        Data.Add(new Tuple<int, int>(X, Width));

        if (Round <= Height)
        {
            // don't change track near start line
            TurnRound = 0;
            ChangeWidthRound = 0;
        }

        if (TurnRound > 0)
        {
            // turn
            TurnRound--;
            X += Step;
            if (X < 1 || X > View.Width - Width)
            {
                // view limit reached, stop turning
                X -= Step;
                TurnRound = 0;
            }
        }
        else if (ChangeWidthRound > 0)
        {
            // change width
            ChangeWidthRound--;
            Width += Step;
            X -= Step;
            if (Width < MinimumWidth || Width > MaximumWidth)
            {
                // width limit reached, stop changing width
                Width -= Step;
                ChangeWidthRound = 0;
            }
            if (X < 1 || X > Width - Width)
            {
                // view limit reached, stop changing width
                X += Step;
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

        // update round parameters
        Game.RoundParameters = new Tuple<int, int>
            (TurnRound, ChangeWidthRound);

    }


    internal static void Draw()
    {

        // dessin de la piste de course
        Tuple<int, int> Step = Data[Data.Count - 1];
        int X = Step.Item1;
        int Width = Step.Item2;

        Console.MoveBufferArea(
            0, StartY,
            View.Width + 10, Height - 1,
            0, StartY + 1);

        Console.SetCursorPosition(X, StartY);
        Console.Write(BorderStyle);
        Console.SetCursorPosition(X + Width, StartY);
        Console.Write(BorderStyle);

        //Console.WriteLine(
        //    new string(' ', TrackStep.Item1)
        //    + TrackBorder
        //    + new string(' ', TrackStep.Item2)
        //    + TrackBorder);

        Thread.Sleep(10);


    }

}
