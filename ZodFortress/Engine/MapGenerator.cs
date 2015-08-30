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

        BoardUnit Rock = new BoardUnit(UnitType.Rock, 'O', ConsoleColor.DarkGreen, ConsoleColor.Gray, 5, 3, false);
        BoardUnit Grass = new BoardUnit(UnitType.Grass, ' ', ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, 1, 1, true);
        BoardUnit Water = new BoardUnit(UnitType.Water, '~', ConsoleColor.DarkBlue, ConsoleColor.Blue, 1000, 1000, false);
        BoardUnit Lava = new BoardUnit(UnitType.Lava, '~', ConsoleColor.Red, ConsoleColor.Yellow, 1000, 1000, false);
        BoardUnit Road = new BoardUnit(UnitType.Road, ' ', ConsoleColor.DarkYellow, ConsoleColor.DarkYellow, 10, 10, true);
        BoardUnit StoneWall = new BoardUnit(UnitType.StoneWall, ' ', ConsoleColor.Gray, ConsoleColor.Gray, 8, 5, false);
        BoardUnit WoodWall = new BoardUnit(UnitType.WoodWall, ' ', ConsoleColor.DarkRed, ConsoleColor.DarkRed, 5, 5, false);
        BoardUnit Tree = new BoardUnit(UnitType.Tree, 'Ϫ', ConsoleColor.DarkGreen, ConsoleColor.Green, 1, 2, false);
        BoardUnit Floor = new BoardUnit(UnitType.Floor, ' ', ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta, 3, 4, false);
            
        public void Generate()
        {
            //fill the map with Grass
            int xi = 0;
            int yi = 0;
            while (xi < MapWidth)
            {
                xi++;
                while (yi < MapHeight)
                {
                    PlaceBlock(Grass, xi, yi);
                    yi++;
                }
                yi = 0;
            }

            //fill the map with Trees
            int xii = 0;
            int yii = 0;
            Random rng = new Random();
            while (xii < MapWidth)
            {
                int ri = rng.Next(0, 9);
                xii++;
                while (yii < MapHeight)
                {
                    if (ri == 1)
                    {
                        PlaceBlock(Tree, xii, yii);
                    }
                    yii++;
                }
                yii = 0;
            }

            //fill the map with Rocks
            int xiii = 0;
            int yiii = 0;
            Random rngi = new Random();
            while (xii < MapWidth)
            {
                int rii = rngi.Next(0, 10);
                xii++;
                while (yiii < MapHeight)
                {
                    if (rii == 1)
                    {
                        PlaceBlock(Rock, xiii, yiii);
                    }
                    yiii++;
                }
                yiii = 0;
            }
        }
        public void PlaceBlock(BoardUnit unit, int x, int y)
        {
            if (x < 0 || x >= mainBoard.Depth.First().BoardSize.Width || y < 0 || y >= mainBoard.Depth.First().BoardSize.Height)
                return;
            mainBoard[x, y, 0] = unit;
        }
        public void PlaceStoneHouse(int x, int y)
        {
            PlaceBlock(StoneWall, x, y);
            PlaceBlock(Floor, x + 1, y);//this is the door
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
        public void PlaceWoodHouse(int x, int y)
        {
            PlaceBlock(WoodWall, x, y);
            PlaceBlock(Floor, x + 1, y);//this is the door
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
