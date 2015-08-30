using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //handling input
            PlaceCursor(37, 2);
            Console.Write(">");
            Console.ReadLine();
        }
        static void Draw()

        {
            //clear the screen
            Console.Clear();
            //draw the overlay 28x36
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
                            //case 23:
                            //    PlaceCursor(0, i + 1);
                            //    Console.Write("N");
                            //    break;
                            //case 24:
                            //    PlaceCursor(0, i + 1);
                            //    Console.Write("O");
                            //    break;
                            //case 25:
                            //    PlaceCursor(0, i + 1);
                            //    Console.Write("P");
                            //    break;
                    }
                }
                i++;
            }
                
                int ii = 0;
                while (ii < 22)
                {
                PlaceCursor(36, ii + 2);
                Console.Write("|");
                ii++;
                }
            #endregion
            Console.ResetColor();

            
        }
        static void OutPutText(String Text)
        {
            List<string> lstinternalcounter = Text.Select(c => c.ToString()).ToList();

        }
        static void PlaceCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        #region InputEvent

        #endregion
    }
}
