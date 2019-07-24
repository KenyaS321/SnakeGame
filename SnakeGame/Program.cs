using System;

namespace SnakeGame
{
    class Program
    {
        private static object m;

        static void Main(string[] args)
        {
            int[] xPosition = new int[50];
               xPosition[0]= 35;
            int[] yPosition = new int[50];
                yPosition[0]= 20;
            int appleXDim = 10;
            int appleYDim = 10;
            int applesEaten = 0;

            decimal gameSpeed = 150m;

            bool isGameon = true;
            bool isWallhit = false;
            bool isAppleEaten = false;

            Random random = new Random();



            Console.SetCursorPosition(xPosition[0], yPosition[0]);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine((char)214);

            setApplePositionOnScreen(random, out appleXDim, out appleYDim);
            paintApple(appleXDim, appleYDim);

            //BUILD WALL
            buildwall();

            //GET SNAKE TO MOVE

            ConsoleKey command = Console.ReadKey().Key;

            do
            {
                switch (command)
                {

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]++;
                        break;


                }
                //PAINT THE SNAKE
                paintSnake(applesEaten, xPosition, out xPosition, out yPosition);


                Console.SetCursorPosition(xPosition, yPosition);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine((char)214);

                //DETECT WHEN SNAKE HITS BOUNDARY

                isWallhit = DidSnakeHitWall(xPosition[0], yPosition[0]);

                if (isWallhit)
                {
                    isGameon = false;
                    Console.SetCursorPosition(28, 20);
                    Console.WriteLine("The Snake hit the wall and died.");
                }

                //DETECT WHEN APPLE WAS EATEN
                isAppleEaten = determineIfAppleWasEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);

                // PLACE APPLE ON BOARD
                if (isAppleEaten)
                {
                    setApplePositionOnScreen(random, out appleXDim, out appleYDim);
                    paintApple(appleXDim, appleYDim);
                    //KEEP TRACK OF HOW MANY APPLES EATEN
                    applesEaten++;
                    //MAKE SNAKE FASTER
                    gameSpeed *= .925m;
                }


                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(Convert.ToInt32 (gameSpeed));

            } while (isGameon);

            //MAKE SNAKE LONGER

            //SLOW GAME DOWN




        }

        private static void paintSnake(int applesEaten, int[] xPositionIn, out int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            //PAINT THE HEAD

            //PAINT THE BODY

            //ERASE LAST PART OF SNAKE

            //RECORD LOCATION OF EACH BODY PART

            //RETURN THE NEW ARRAY
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;

        }

        private static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40) return true; return false;
        }
        private static void buildwall()
        {
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("s");
                Console.SetCursorPosition(70, i);
                Console.Write("s");

            }
            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("s");
                Console.SetCursorPosition(i, 40);
                Console.Write("s");
            }
        }

        private static void setApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
        {
            appleXDim = random.Next(0 + 2, 70 - 2);
            appleYDim = random.Next(0 + 2, 40 - 2);
        }
        private static void paintApple(int appleXDim, int appleYDim)
        {
            Console.SetCursorPosition(appleXDim, appleYDim);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }

        private static bool determineIfAppleWasEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
        {
            if (xPosition == appleXDim && appleYDim == yPosition) return true; return false;
        }

    }
}