using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClock
{
    internal class Program
    {

        // size parameters for 1920x1080 at 125% and console font size at 20px
        static int ViewWidth = 105;
        static int ViewHeight = 40;

        public static void Main()
        {
            InitializeView(ViewWidth, ViewHeight);
            while (true)
            {
                DrawClock();
                DrawClockHands();
                Thread.Sleep(990);
            }

            Console.SetCursorPosition(0, 0);
            Console.ReadLine();
        }


        private static void InitializeView(int Width, int Height)
        {
            Console.WindowWidth = Width;
            Console.WindowHeight = Height;

            Console.CursorVisible = false;

        }

        private static void DrawClock(
            ConsoleColor BorderColor = ConsoleColor.White,
            ConsoleColor ShortLinesColor = ConsoleColor.Blue,
            int ShortLinesLength = 4,
            ConsoleColor LongLinesColor = ConsoleColor.DarkBlue,
            int LongLinesLength = 7,
            string ClockDrawing = " ")
        {
            // define variables
            int ClockRadiusX = (ViewWidth - 20) / 2;
            int ClockRadiusY = (ViewHeight - 5) / 2;
            int ClockCenterX = ViewWidth / 2;
            int ClockCenterY = ViewHeight / 2;
            double AngleStep = 0.02;
            double Angle;
            int X1, Y1, X2, Y2;
            
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            // show seconds/minutes lines and hours
            Angle = -(Math.PI / 2);
            for (int Second = 1; Second <= 60; Second++)
            {

                X1 = (int)(Math.Cos(Angle) * (ClockRadiusX + 2)) + ClockCenterX;
                Y1 = (int)(Math.Sin(Angle) * (ClockRadiusY + 1)) + ClockCenterY;

                int LineLength = ShortLinesLength;
                ConsoleColor LineColor = ShortLinesColor;

                if (Second % 5 == 0)
                {
                    LineLength = LongLinesLength;
                    LineColor = LongLinesColor;
                }
                else if ((Second - 1) % 5 == 0)
                {
                    Console.SetCursorPosition(X1, Y1);
                    if (Second - 1 == 0)
                        Console.Write("12");
                    else
                        Console.Write((Second / 5).ToString());
                }

                Angle += (Math.PI * 2) / 60;
                
                X1 = (int)(Math.Cos(Angle) * ClockRadiusX) + ClockCenterX;
                Y1 = (int)(Math.Sin(Angle) * ClockRadiusY) + ClockCenterY;

                X2 = (int)(Math.Cos(Angle) * (ClockRadiusX - LineLength)) + ClockCenterX;
                Y2 = (int)(Math.Sin(Angle) * (ClockRadiusY - LineLength)) + ClockCenterY;

                DrawLine(X1, Y1, X2, Y2, LineColor);

            }

            // draw border
            Console.BackgroundColor = BorderColor;
            for (Angle = 0; Angle <= 2 * Math.PI; Angle += AngleStep)
            {
                X1 = (int)(Math.Cos(Angle) * ClockRadiusX) + ClockCenterX;
                Y1 = (int)(Math.Sin(Angle) * ClockRadiusY) + ClockCenterY;
                Console.SetCursorPosition(X1, Y1);
                Console.Write(ClockDrawing);
            }

            Console.ResetColor();
        }


        private static void DrawClockHands(
            ConsoleColor SecondsColor = ConsoleColor.Yellow,
            int SecondsRadiusStep = -3, 
            ConsoleColor MinutesColor = ConsoleColor.White,
            int MinutesRadiusStep = -6,
            ConsoleColor HoursColor = ConsoleColor.Green,
            int HoursRadiusStep = -9,
            string ClockDrawing = " ")
        {
            // define variables
            int ClockRadiusX = (ViewWidth - 20) / 2;
            int ClockRadiusY = (ViewHeight - 5) / 2;
            int ClockCenterX = ViewWidth / 2;
            int ClockCenterY = ViewHeight / 2;
            int XStart, YStart, XEnd, YEnd;
            double Angle;
            Console.ForegroundColor = ConsoleColor.Black;

            // show seconds hand
            Angle = -(Math.PI / 2) + ((Math.PI / 30) * DateTime.Now.Second);
            XStart = (int)(Math.Cos(Angle) * 1) + ClockCenterX;
            YStart = (int)(Math.Sin(Angle) * 1) + ClockCenterY;
            XEnd = (int)(Math.Cos(Angle) * (ClockRadiusX + SecondsRadiusStep)) + ClockCenterX;
            YEnd = (int)(Math.Sin(Angle) * (ClockRadiusY + SecondsRadiusStep)) + ClockCenterY;
            DrawLine(XStart, YStart, XEnd, YEnd, SecondsColor, LineDrawing: ClockDrawing);

            // show minutes hand
            Angle = -(Math.PI / 2) + ((Math.PI / 30) * DateTime.Now.Minute);
            XStart = (int)(Math.Cos(Angle) * 1) + ClockCenterX;
            YStart = (int)(Math.Sin(Angle) * 1) + ClockCenterY;
            XEnd = (int)(Math.Cos(Angle) * (ClockRadiusX + MinutesRadiusStep)) + ClockCenterX;
            YEnd = (int)(Math.Sin(Angle) * (ClockRadiusY + MinutesRadiusStep)) + ClockCenterY;
            DrawLine(XStart, YStart, XEnd, YEnd, MinutesColor, LineDrawing: ClockDrawing);

            // show hours hand
            Angle = -(Math.PI / 2) + ((Math.PI / 6) * (DateTime.Now.Hour));
            XStart = (int)(Math.Cos(Angle) * 1) + ClockCenterX;
            YStart = (int)(Math.Sin(Angle) * 1) + ClockCenterY;
            XEnd = (int)(Math.Cos(Angle) * (ClockRadiusX + HoursRadiusStep)) + ClockCenterX;
            YEnd = (int)(Math.Sin(Angle) * (ClockRadiusY + HoursRadiusStep)) + ClockCenterY;
            DrawLine(XStart, YStart, XEnd, YEnd, HoursColor, LineDrawing: ClockDrawing);

            Console.ResetColor();
        }


        private static void DrawLine(
            int X1, int Y1, int X2, int Y2,
            ConsoleColor BackColor = ConsoleColor.Black,
            ConsoleColor ForeColor = ConsoleColor.White,
            string LineDrawing = " ")
        {
            double MaxSteps = Math.Max(Math.Abs(X2 - X1), Math.Abs(Y2 - Y1));
            double StepX = ((X2 - X1) / MaxSteps);
            double StepY = ((Y2 - Y1) / MaxSteps);

            Console.ForegroundColor = ForeColor;
            Console.BackgroundColor= BackColor;

            for (int Step = 0; Step < MaxSteps; Step++)
            {
                int NextX = (int)(X1 + (StepX * Step));
                int NextY = (int)(Y1 + (StepY * Step));
                Console.SetCursorPosition(NextX, NextY);
                Console.Write(LineDrawing);
            }

            Console.ResetColor();
        }

        private static void Draw100Line()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 2);
                Console.Write(" ");

                if (i % 10 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(i, 4);
                    Console.Write(i.ToString());
                }

                Thread.Sleep(10);
            }

            Console.ResetColor();
            Console.SetCursorPosition(0, 10);
        }

    }
}
