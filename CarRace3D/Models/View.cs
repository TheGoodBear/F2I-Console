using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace2D.Models;

internal static class View
{

    internal const int Width = 100;
    internal const int Height = 40;
    internal const int HUDLineOrigin = 1;


    internal static void Initialize()
    {
        Console.SetWindowSize(Width, Height);
        Console.CursorVisible = false;
        Console.Clear();
    }

}
