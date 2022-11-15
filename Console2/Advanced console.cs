//// https://spectreconsole.net/
//using Spectre.Console;

//AnsiConsole.MarkupLine("[bold yellow on blue]Hello[/]");
//AnsiConsole.MarkupLine("[default on blue]World[/]");

//AnsiConsole.MarkupLine("Hello :globe_showing_europe_africa:!");

//AnsiConsole.MarkupLine("[red]Foo[/] ");
//AnsiConsole.MarkupLine("[#ff0000]Bar[/] ");
//AnsiConsole.MarkupLine("[rgb(255,0,0)]Baz[/] ");

//// Create a list of Items, apply separate styles to each
//var columns = new List<Text>(){
//    new Text("Item 1", new Style(Color.Red, Color.Black)),
//    new Text("Item 2", new Style(Color.Green, Color.Black)),
//    new Text("Item 3", new Style(Color.Blue, Color.Black))
//};

//// Renders each item with own style
//AnsiConsole.Write(new Columns(columns));


//// Create a canvas
//var canvas = new Canvas(16, 16);

//// Draw some shapes
//for (var i = 0; i < canvas.Width; i++)
//{
//    // Cross
//    canvas.SetPixel(i, i, Color.White);
//    canvas.SetPixel(canvas.Width - i - 1, i, Color.White);

//    // Border
//    canvas.SetPixel(i, 0, Color.Red);
//    canvas.SetPixel(0, i, Color.Green);
//    canvas.SetPixel(i, canvas.Height - 1, Color.Blue);
//    canvas.SetPixel(canvas.Width - 1, i, Color.Yellow);
//}

//// Render the canvas
//AnsiConsole.Write(canvas);

using System;
using System.Diagnostics.Metrics;
using System.Threading;

class Sample
{
    public static void Main()
    {
        ConsoleKeyInfo cki;

        Console.CursorVisible = false;
        do
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\nPress a key to display; press the 'x' key to quit.");

            // Your code could perform some useful task in the following loop. However,
            // for the sake of this example we'll merely pause for a quarter second.

            int Counter = 0;
            while (Console.KeyAvailable == false)
            {
                Console.SetCursorPosition(0, 4);
                Console.Write(Counter);
                Thread.Sleep(100); // Loop until input is entered.
                Counter++;
            }


            cki = Console.ReadKey(false);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("You pressed the '{0}' key.", cki.Key);
        } while (cki.Key != ConsoleKey.X);
    }
}

//Console.BackgroundColor = ConsoleColor.Green;
//Console.ForegroundColor = ConsoleColor.Red;
//for (int i = 0; i < 10; i++)
//{
//    Console.SetCursorPosition(i, i);
//    Console.WriteLine(i);
//}
