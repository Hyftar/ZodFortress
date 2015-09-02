using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZodFortress.Engine.Units;
using ZodFortress.Engine;
using ZodFortress;

namespace ZodFortressCLI
{
    class Program
    {

        internal static bool IsRuning = true;
        internal static Point CursorPosition = new Point(); // Will be used later.
        
        static void Main(string[] args)
        {

            var map = new Map(100,100, 1, MapGenerator.Grass);
            var generator = new MapGenerator(map);
            var player = new Player(map.Layers.First(), new Point(50,50));
            Draw(map, player);
            Update(map, player);

            Console.Title = "ZodFortress";

            while (IsRuning)
            {
                Draw(map, player);
                Update(map, player);
                PlayerAction(map.Layers.First(), new CommandParser().Parse(Console.ReadLine()), player);
                Console.ReadKey();
            }
        }

        static void Update(Map map, Player player)
        {
            // Handling output
            //OutputText("To be, or not to be: that is the question: Whether 'tis nobler in the mind to suffer The slings and arrows of outrageous fortune, Or to take arms against a sea of troubles, And by opposing end them? To die: to sleep; No more; and by a sleep to say we end The heart-ache and the thousand natural shocks ");
            // Handling input
            PlaceCursor(37, 2);
            Console.Write(">");
        }

        static void Draw(Map map, Player player)
        {
            // Clear the screen
            Console.Clear();
            // Draw the overlay 28x36
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            PlaceCursor(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to ZodFortress - Now playing ");
            PlaceCursor(0, 1);
            Console.WriteLine("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ ");
            int i = 0;
            while (i < 80)
            {
                PlaceCursor(i, 24);
                Console.Write(" ");
                i++;
            }


            #region VerticalHell
            i = 0;
            while (i < 23)
            {
                if (i <= 9)
                {
                    PlaceCursor(0, i + 1);
                    Console.Write(i.ToString());
                }
                else
                {
                    PlaceCursor(0, i + 1);
                    switch (i)
                    {
                        case 10:
                            PlaceCursor(0, i + 1);
                            Console.Write("A");
                            break;
                        case 11:
                            PlaceCursor(0, i + 1);
                            Console.Write("B");
                            break;
                        case 12:
                            PlaceCursor(0, i + 1);
                            Console.Write("C");
                            break;
                        case 13:
                            PlaceCursor(0, i + 1);
                            Console.Write("D");
                            break;
                        case 14:
                            PlaceCursor(0, i + 1);
                            Console.Write("E");
                            break;
                        case 15:
                            PlaceCursor(0, i + 1);
                            Console.Write("F");
                            break;
                        case 16:
                            PlaceCursor(0, i + 1);
                            Console.Write("G");
                            break;
                        case 17:
                            PlaceCursor(0, i + 1);
                            Console.Write("H");
                            break;
                        case 18:
                            PlaceCursor(0, i + 1);
                            Console.Write("I");
                            break;
                        case 19:
                            PlaceCursor(0, i + 1);
                            Console.Write("J");
                            break;
                        case 20:
                            PlaceCursor(0, i + 1);
                            Console.Write("K");
                            break;
                        case 21:
                            PlaceCursor(0, i + 1);
                            Console.Write("L");
                            break;
                        case 22:
                            PlaceCursor(0, i + 1);
                            Console.Write("M");
                            break;
                    }
                }
                i++;
            }
            
            i = 0;
            while (i < 22)
            {
                PlaceCursor(36, i + 2);
                Console.Write("|");
                i++;
            }
            #endregion


            Console.ResetColor();
            PlaceCursor(75, 0);
            Console.Write("N");
            PlaceCursor(73, 1);
            Console.Write("W");
            PlaceCursor(77, 1);
            Console.Write("E");
            PlaceCursor(75, 2);
            Console.Write("S");


            //draw the viewport
            DrawBlocks(map, player);
            Console.ResetColor();

            // Reset cursor position
            PlaceCursor(0, 0);
        }
        private static void DrawBlocks(Map map, Player player)
        {
            int px = player.Position.X - 16;
            int py = player.Position.Y - 10;

            int x = 0;
            int y = 0;
            while (x <= 33)
            {
                while (y<=21)
                {
                    PlaceCursor(x +1, y +2);
                    Console.ForegroundColor = map[x + px, y + py, 0].FontColor;
                    Console.BackgroundColor = map[x + px, y + py, 0].BackColor;
                    Console.Write(map[x + px, y + py, 0].Character);
                    y++;
                }
                x++;
                y = 0;
            }
            x = 0;

            PlaceCursor(17, 12);
            Console.BackgroundColor = map[16 + px, 10 + py, 0].BackColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("H");
        }
        private static void OutputText(String Text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var splText = Regex.Matches(Text, ".{1,43}").Cast<Match>().Select(m => m.Value);
            int i = 0;
            foreach (var item in splText)
            {
                PlaceCursor(37, 3 + i);
                Console.Write(item);
                i++;
            }
            Console.ResetColor();
        }

        private static void PlaceCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        private void PlayerDead()
        {
            PlaceCursor(25, 14);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You lost to Zod");
            Console.ResetColor();
            PlaceCursor(0, 0);
            Program.IsRuning = false;
            Console.Read();
        }
        #region InputEvent
        private static bool PlayerAction(Board board, Command input, Player player)
        {
            if (!input.Success)
            {
                OutputText("This is not a valid command");
                return false;
            }
            else if (input.GameCommand.Any())
            {
                switch (input.GameCommand)
                {
                    case "?":
                    case "halp":
                    case "help":
                    case "wtf":
                    case "fuck":
                        OutputText("Commands must be composed of 3 keys { Command or order, object, location } see Github.com/Hyftar/ZodFortress/README.md for more details.");
                        return false;

                    case "exit":
                    case "leave":
                    case "quit":
                    case "end":
                        Environment.Exit(0);
                        break;

                    case "kill":
                    case "destroy":
                    case "attack":
                        switch (input.Location)
                        {
                            case "up":
                            case "north":
                            case "n":
                            case "forward":
                                break;
                            default:
                                OutputText("Location not recognized.");
                                return false; ;
                        }
                        break;

                    default:
                        OutputText("Command not recognized.");
                        return false;
                }
            }
            else if (input.Order.Any() && input.Location.Any())
            {
                switch (input.Order)
                {
                    case "move":
                    case "sprint":
                    case "step":
                    case "maneuver":
                    case "walk":
                    case "run":
                        switch (input.Location)
                        {
                            case "up":
                            case "forward":
                            case "north":
                            case "n":
                                if (player.Move(MovementDirection.Up))
                                {
                                    OutputText("Moved up.");
                                    return true;
                                }
                                else
                                    OutputText("Failed to move up.");
                                return false;
                            case "down":
                            case "backward":
                            case "south":
                            case "s":
                                if (player.Move(MovementDirection.Down))
                                {
                                    OutputText("Moved down.");
                                    return true;
                                }
                                else
                                    OutputText("Failed to move down.");
                                return false;
                            case "left":
                            case "w":
                            case "west":
                                if (player.Move(MovementDirection.Left))
                                {
                                    OutputText("Moved left.");
                                    return true;
                                }
                                else
                                    OutputText("Failed to move left.");
                                return false;
                            case "right":
                            case "east":
                            case "e":
                                if (player.Move(MovementDirection.Right))
                                {
                                    OutputText("Moved right.");
                                    return true;
                                }
                                else
                                    OutputText("Failed to move right.");
                                return false;
                            default:
                                OutputText("Location not recognized.");
                                return false;
                        }
                    default:
                        return false;
                }

            }

            return false;
        }
        #endregion
    }
}
