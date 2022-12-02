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

        Draw(X, Y, X + XStep, Y + YStep);
        X += XStep * CurrentXStep;
        Y += YStep;
    }


    internal static void MoveToStartLine()
    {
        for (int Line = 1; Line <= Track.LineStartY ;Line++)
        {
            int NewY = Track.StartY + Track.Height - Line;
            Draw(X, Y, X, NewY);
            Y = NewY;
            Thread.Sleep(250);
        }
    }

    private static void Draw(
        int XOld,
        int YOld,
        int X,
        int Y)
    {
        Console.SetCursorPosition(XOld, YOld);
        Console.Write(" ");

        Console.SetCursorPosition(X, Y);
        Console.Write(Image);
    }

}
