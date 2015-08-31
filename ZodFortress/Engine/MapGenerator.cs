using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodFortress.Engine.Units;

namespace ZodFortress.Engine
{
    public class MapGenerator
    {
        public static int MapWidth = 99;
        public static int MapHeight = 99;

        public Map mainBoard = new Map(MapWidth, MapHeight, 1);

        BoardBlock Rock = new BoardBlock(UnitType.Rock, 'O', ConsoleColor.DarkGreen, ConsoleColor.Gray, 5, 3, false);
        BoardBlock Grass = new BoardBlock(UnitType.Grass, ' ', ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, 1, 1, true);
        BoardBlock Water = new BoardBlock(UnitType.Water, '~', ConsoleColor.DarkBlue, ConsoleColor.Blue, 1000, 1000, false);
        BoardBlock Lava = new BoardBlock(UnitType.Lava, '~', ConsoleColor.Red, ConsoleColor.Yellow, 1000, 1000, false);
        BoardBlock Road = new BoardBlock(UnitType.Road, ' ', ConsoleColor.DarkYellow, ConsoleColor.DarkYellow, 10, 10, true);
        BoardBlock StoneWall = new BoardBlock(UnitType.StoneWall, ' ', ConsoleColor.Gray, ConsoleColor.Gray, 8, 5, false);
        BoardBlock WoodWall = new BoardBlock(UnitType.WoodWall, ' ', ConsoleColor.DarkRed, ConsoleColor.DarkRed, 5, 5, false);
        BoardBlock Tree = new BoardBlock(UnitType.Tree, 'Ϫ', ConsoleColor.DarkGreen, ConsoleColor.Green, 1, 2, false);
        BoardBlock Floor = new BoardBlock(UnitType.Floor, ' ', ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta, 3, 4, false);
        
        /// <summary>
        /// Generates a random map.
        /// </summary>
        public void Generate()
        {
            // Fill the map with Grass -> The map is already full of grass by default
            //for (int i = 0; i < MapWidth; i++)
            //    for (int j = 0; j < MapHeight; j++)
            //        PlaceBlock(Grass, i, j);

            // Fill the map with Trees
            Random rng = new Random();
            int r = 0;
            for (int i = 0; i < MapWidth; i++)
            {
                for (int j = 0; j < MapHeight; j++)
                {
                    r = rng.Next(9);
                    if (r == 0)
                        PlaceBlock(Tree, i, j);
                    else if (r == 1)
                        PlaceBlock(Rock, i, j);
                }
            }
        }

        /// <summary>
        /// Places a block or a unit at the specified location in the map.
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void PlaceBlock(BoardBlock unit, int x, int y)
        {
            if (x < 0 || x >= mainBoard.Depth.First().BoardSize.Width || y < 0 || y >= mainBoard.Depth.First().BoardSize.Height)
                return;

            mainBoard[x, y, 0] = unit;
        }

        /// <summary>
        /// Places a stone house at the specified location.
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="y">Y Coordinate</param>
        public void PlaceStoneHouse(int x, int y)
        {
            PlaceBlock(StoneWall, x, y);
            PlaceBlock(Floor, x + 1, y); // This is the door
            PlaceBlock(StoneWall, x + 2, y);
            PlaceBlock(StoneWall, x + 3, y);
            PlaceBlock(StoneWall, x, y + 1);
            PlaceBlock(StoneWall, x, y + 2);
            PlaceBlock(StoneWall, x, y + 3);
            PlaceBlock(StoneWall, x + 3, y + 1);
            PlaceBlock(StoneWall, x + 2, y + 3);
            PlaceBlock(StoneWall, x, y + 3);
            PlaceBlock(StoneWall, x + 2, y + 3);
            PlaceBlock(StoneWall, x + 3, y + 3);

            PlaceBlock(Floor, x + 1, y + 1);
            PlaceBlock(Floor, x + 2, y + 3);
            PlaceBlock(Floor, x + 1, y + 2);
            PlaceBlock(Floor, x + 2, y + 3);
        }

        /// <summary>
        /// Places a wood house at the specified location.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public void PlaceWoodHouse(int x, int y)
        {
            PlaceBlock(WoodWall, x, y);
            PlaceBlock(Floor, x + 1, y); // This is the door
            PlaceBlock(WoodWall, x + 2, y);
            PlaceBlock(WoodWall, x + 3, y);
            PlaceBlock(WoodWall, x, y + 1);
            PlaceBlock(WoodWall, x, y + 2);
            PlaceBlock(WoodWall, x, y + 3);
            PlaceBlock(WoodWall, x + 3, y + 1);
            PlaceBlock(WoodWall, x + 2, y + 3);
            PlaceBlock(WoodWall, x, y + 3);
            PlaceBlock(WoodWall, x + 2, y + 3);
            PlaceBlock(WoodWall, x + 3, y + 3);

            PlaceBlock(Floor, x + 1, y + 1);
            PlaceBlock(Floor, x + 2, y + 3);
            PlaceBlock(Floor, x + 1, y + 2);
            PlaceBlock(Floor, x + 2, y + 3);
        }
    }
}
