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

            BoardUnit Rock = new BoardUnit(UnitType.Rock, 'O', ConsoleColor.DarkGreen, ConsoleColor.Gray, 5, 3);
            BoardUnit Grass = new BoardUnit(UnitType.Grass, ' ', ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, 1, 1);
            BoardUnit Water = new BoardUnit(UnitType.Water, '~', ConsoleColor.DarkBlue, ConsoleColor.Blue, 1000, 1000);
            BoardUnit Lava = new BoardUnit(UnitType.Lava, '~', ConsoleColor.Red, ConsoleColor.Yellow, 1000, 1000);
            BoardUnit Road = new BoardUnit(UnitType.Road, ' ', ConsoleColor.DarkYellow, ConsoleColor.DarkYellow, 10, 10);
            BoardUnit StoneWall = new BoardUnit(UnitType.StoneWall, ' ', ConsoleColor.Gray, ConsoleColor.Gray, 8, 5);
            BoardUnit WoodWall = new BoardUnit(UnitType.WoodWall, ' ', ConsoleColor.DarkRed, ConsoleColor.DarkRed, 5, 5);
            BoardUnit Tree = new BoardUnit(UnitType.Tree, 'Ϫ', ConsoleColor.DarkGreen, ConsoleColor.Green, 1, 2);
            BoardUnit Floor = new BoardUnit(UnitType.Floor, ' ', ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta, 3, 4);
            
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
        }
        public void PlaceBlock(BoardUnit unit, int x, int y)
        {
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
