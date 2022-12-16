using CarRace2D.Code_files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace2D.Models;

internal static class Car
{

    const int SpeedMin = 25;
    const int SpeedMax = 150;
    internal static int Speed = SpeedMax;
    internal const int SpeedStep = 25;
    const int XMin = 10;
    const int XMax = View.Width - XMin;
    const int CurrentXStep = 1;
    internal static int X = View.Width / 2;
    internal static int Y = 10;
    const string Image = "Ö";

    public enum eDraw
    {
        Hide,
        Show,
        Both
    }


    internal static void ChangeSpeed(
        int Step)
    {
        // accelerate, decelerate

        if (Step == -1 && Speed > SpeedMin)
            Speed -= SpeedStep;
        else if (Step == 1 && Speed < SpeedMax)
            Speed += SpeedStep;
    }


    internal static void ChangePosition(
        int XStep,
        int YStep = 0)
    {
        // move left/right

        if ((XStep == -1 && X <= XMin)
            || (XStep == 1 && X > XMax))
            XStep = 0;

        Draw(false);
        X += XStep * CurrentXStep;
        Y += YStep;
        Draw();
    }


    internal static void MoveToStartLine()
    {
        for (int Line = 1; Line <= Track.LineStartY ;Line++)
        {
            Draw(false);
            Y = Track.StartY + Track.Height - Line;
            Draw();
            Thread.Sleep(250);
        }
    }

    public static bool Draw(
        bool Show = true)
    {
        bool Crash = false;

        Console.SetCursorPosition(X, Y);
        string CarImage = " ";

        if (Show)
        {
            CarImage = Image;
            Crash = (Utilities.GetCharacterAt(X, Y).ToString() != " ");
        }

        Console.Write(CarImage);

        return Crash;
    }

}
