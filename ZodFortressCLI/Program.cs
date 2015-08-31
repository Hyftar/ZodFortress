using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZodFortressCLI
{
    class Program
    {
        public static bool IsRuning = true;
        static void Main(string[] args)
        {
            Console.Title = "ZodFortress";
            while (IsRuning)
            {
                Draw();
                Update();
            }
        }

        static void Update()
        {
            // Handling output
            OutputText("To be, or not to be: that is the question: Whether 'tis nobler in the mind to suffer The slings and arrows of outrageous fortune, Or to take arms against a sea of troubles, And by opposing end them? To die: to sleep; No more; and by a sleep to say we end The heart-ache and the thousand natural shocks ");
            // Handling input
            PlaceCursor(37, 2);
            Console.Write(">");
            Console.ReadLine();
        }

        static void Draw()
        {
            // Clear the screen
            Console.Clear();
            // Draw the overlay 28x36
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            PlaceCursor(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Zod         Now playing //");
            PlaceCursor(0, 1);
            Console.WriteLine("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ ");
            int iii = 0;
            while (iii < 80)
            {
                PlaceCursor(iii, 24);
                Console.Write(" ");
                iii++;
            }


            #region VerticalHell
            int i = 0;
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

            // Reset cursor position
            PlaceCursor(0, 0);
        }
        static void OutputText(String Text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var splText = Regex.Matches(Text, ".{1, 43}").Cast<Match>().Select(m => m.Value);
            int i = 0;
            foreach (var item in splText)
            {
                PlaceCursor(37, 3 + i);
                Console.Write(item);
                i++;
            }
            Console.ResetColor();
        }

        static void PlaceCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void PlayerDead()
        {
            PlaceCursor(25, 14);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You lost to Zod");
            Console.ResetColor();
            PlaceCursor(0, 0);
            Console.Read();
            Program.IsRuning = false;
        }
        #region InputEvent

        #endregion
    }
}
