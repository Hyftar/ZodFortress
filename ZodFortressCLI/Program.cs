using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text.RegularExpressions;
using ZodFortress.Engine.Units;
using ZodFortress.Engine;

namespace ZodFortressCLI
{
    internal class Program
    {
        internal static bool IsRuning = true;

        [STAThread]
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
            // Test outputs
            //OutputText("aaaaa bbbbb ccccc ddddd eeeee ffffff ggggggg hhhhhhhhhhh iiiiiiii jjjjjjjj kkkkkkkkkkkk lllllll");
            //OutputText("To be, or not to be: that is the question: Whether 'tis nobler in the mind to suffeer The slings and arrows of outrageous fortune, Or to take arms against a sea of troubles, And by opposing end them? To die: to sleep; No more; and by a sleep to say we end The heart-ache and the thousand natural shocks That Flesh is heir to? 'Tis a consummation Devoutly to be wished. To die, to sleep, ");
            //OutputText("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            // Handling input
            PlaceCursor(37, 2);
            Console.Write('>');
        }

        static void Draw(Map map, Player player)
        {
            // Clear the screen
            Console.Clear();
            // Draw the overlay 28x36
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            PlaceCursor(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to ZodFortress - Now playing");
            PlaceCursor(0, 1);
            Console.WriteLine("0123456789ABCDEFGHIJKLMNOPQRSTUVWXY ");
            int i = 0;
            while (i < 80)
            {
                PlaceCursor(i, 24);
                Console.Write('\x20');
                i++;
            }

            i = 0;
            char letter = 'A';
            while (i < 23)
            {
                PlaceCursor(35, i + 1);
                Console.Write('|');
                PlaceCursor(0, i + 1);
                if (i <= 10)
                    Console.Write(i.ToString());
                else
                    Console.Write(letter++);
                i++;
            }
            
            Console.ResetColor();
            PlaceCursor(75, 0);
            Console.Write('N');
            PlaceCursor(73, 1);
            Console.Write('W');
            PlaceCursor(77, 1);
            Console.Write('E');
            PlaceCursor(75, 2);
            Console.Write('S');


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
                while (y <= 21)
                {
                    PlaceCursor(x + 1, y + 2);
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
            Console.Write('H');
        }
        private static void OutputText(String Text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int lineLength = 0;
            string line = string.Empty;
            var splText = Regex.Matches(Text, @"\s*([^\s]+)\s*").Cast<Match>().Select(m => m.Groups[1].Value);
            int i = 0;
            foreach (var item in splText)
            {
                lineLength += item.Length + 1;
                if (lineLength < 44)
                    line += item + '\x20';

                else if (item.Length >= 44)
                {
                    string item1 = item.Substring(0, 42) + '-';
                    string item2 = item.Substring(42, item.Length - 42);
                    if (line != string.Empty)
                    {
                        PlaceCursor(37, 3 + i++);
                        Console.Write(line.Trim());
                    }
                    PlaceCursor(37, 3 + i++);
                    Console.Write(item1);
                    line = item2 + '\x20';
                    lineLength = item2.Length + 1;
                }

                else
                {
                    PlaceCursor(37, 3 + i++);
                    Console.Write(line.Trim());
                    lineLength = item.Length + 1;
                    line = item + '\x20';
                }

                if (item == splText.Last())
                {
                    PlaceCursor(37, 3 + i);
                    Console.Write(line.Trim());
                }
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
                    case "halp":
                    case "help":
                    case "wtf":
                    case "fuck":
                        System.Windows.Forms.Clipboard.SetText("https://github.com/Hyftar/ZodFortress/blob/master/README.md");
                        OutputText("Commands must be composed of 3 keys { Command or order, object, location } see https://github.com/Hyftar/ZodFortress/blob/master/README.md for more details. The url was copied to the clipboard.");
                        return false;

                    case "exit":
                    case "leave":
                    case "quit":
                    case "end":
                        Environment.Exit(0);
                        break;
                    // ADD GAME COMMANDS CASES HERE.
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
                    case "advance":
                    case "shift":
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

                    // ADD ORDER CASES HERE.
                    default:
                        return false;
                }

            }

            return false;
        }
        #endregion
    }
}
