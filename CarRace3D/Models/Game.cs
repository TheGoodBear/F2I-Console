namespace CarRace2D.Models;

internal static class Game
{

    internal static int CurrentRound = 0;
    internal static int CurrentDifficulty = 1;
    internal static Tuple<int, int, int> RoundParameters =
        new Tuple<int, int, int>(0, 0, 0);


    internal static void PrepareRace()
    {

        // draw track
        for (int Round = 0; Round <= Track.Height; Round++)
        {
            Track.Create();
            Track.Draw();
        }

        // draw start line
        Console.SetCursorPosition(Track.X + 1, Track.StartY + Track.Height - Track.LineStartY - 1);
        Console.WriteLine(new string(Track.StartLineStyle, Track.Width - 1));

        Thread.Sleep(500);

        // draw car
        Car.MoveToStartLine();

        Console.ReadLine();

    }


    internal static void Loop()
    {
        // main game loop
        Console.CursorVisible = false;
        bool GameInProgress;
        bool Crash = false;
        do
        {

            while (!Console.KeyAvailable)
            {
                DisplayDashboard();
                CurrentRound++;

                Track.Create();
                Crash = Track.Draw();

                if (Crash)
                {
                    CarCrashed();
                    return;
                }

                Thread.Sleep(Car.Speed); // Loop until input is entered
            }

            // a key was pressed
            string ActionKey = (Console.ReadKey(false)).Key.ToString();
            //Console.SetCursorPosition(40, 4);
            //Console.Write($"You pressed the '{KeyPressed}' key.");

            GameInProgress = DoAction(ActionKey);

        } while (GameInProgress);

    }


    private static void DisplayDashboard()
    {
        Console.SetCursorPosition(30, 1);
        Console.Write($"Speed : {Car.Speed / Car.SpeedStep}   Distance : {CurrentRound} m   Difficulty = {CurrentDifficulty}");
        //Console.SetCursorPosition(40, 2);
        //Console.Write($"Car position = {Car.X}");
    }


    private static bool DoAction(
        string ActionKey)
    {
        // change speed
        if (ActionKey == "Z" || ActionKey == "UpArrow")
            Car.ChangeSpeed(1);
        else if (ActionKey == "X" || ActionKey == "DownArrow")
            Car.ChangeSpeed(-1);

        // move left/right
        if (ActionKey == "Q" || ActionKey == "LeftArrow")
            Car.ChangePosition(-1);
        else if (ActionKey == "D" || ActionKey == "RightArrow")
            Car.ChangePosition(1);

        // end game
        return !(ActionKey == "Escape");
    }


    private static void CarCrashed() 
    {
        Console.SetCursorPosition(30, 5);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write($"*** ACCIDENT ***");
    }

}
