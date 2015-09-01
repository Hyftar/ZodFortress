using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodFortress.Engine.Units;

namespace ZodFortress.Engine
{
    public class MapGenerator
    {
        public Map Map { get; private set; }

        public MapGenerator(Map map)
        {
            this.Map = map;
        }

        private static readonly BoardBlock Rock = new BoardBlock(BlockType.Rock, 'o', ConsoleColor.DarkGreen, ConsoleColor.Gray, 5, 3, false);
        private static readonly BoardBlock Grass = new BoardBlock(BlockType.Grass, ' ', ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, 1, 1, true);
        private static readonly BoardBlock Water = new BoardBlock(BlockType.Water, '~', ConsoleColor.DarkBlue, ConsoleColor.Blue, 1000, 1000, false);
        private static readonly BoardBlock Lava = new BoardBlock(BlockType.Lava, '~', ConsoleColor.Red, ConsoleColor.Yellow, 1000, 1000, false);
        private static readonly BoardBlock Road = new BoardBlock(BlockType.Road, ' ', ConsoleColor.DarkYellow, ConsoleColor.DarkYellow, 10, 10, true);
        private static readonly BoardBlock StoneWall = new BoardBlock(BlockType.StoneWall, ' ', ConsoleColor.Gray, ConsoleColor.Gray, 8, 5, false);
        private static readonly BoardBlock WoodWall = new BoardBlock(BlockType.WoodWall, ' ', ConsoleColor.DarkRed, ConsoleColor.DarkRed, 5, 5, false);
        private static readonly BoardBlock Tree = new BoardBlock(BlockType.Tree, 'Ϫ', ConsoleColor.DarkGreen, ConsoleColor.Green, 1, 2, false);
        private static readonly BoardBlock Floor = new BoardBlock(BlockType.Floor, ' ', ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta, 3, 4, false);
        
        /// <summary>
        /// Populates a board with a random configuration.
        /// </summary>
        public void Generate(Board board)
        {
            // Fill the map with Grass -> The map is already full of grass by default
            //for (int i = 0; i < MapWidth; i++)
            //    for (int j = 0; j < MapHeight; j++)
            //        PlaceBlock(Grass, i, j);

            // Fill the map with Trees
            Random rng = new Random();
            int r = 0;
            for (int i = 0; i < board.Size.Width; i++)
                for (int j = 0; j < board.Size.Height; j++)
                {
                    r = rng.Next(9);
                    if (r == 0)
                        PlaceBlock(board, Tree, i, j);
                    else if (r == 1)
                        PlaceBlock(board, Rock, i, j);
                }
        }

        /// <summary>
        /// Places a block at the specified location in the map.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="block"></param>
        /// <param name="point"></param>
        public void PlaceBlock(Board board, BoardBlock block, Point point)
        {
            if (point.X < 0 || point.X >= board.Size.Width || point.Y < 0 || point.Y >= board.Size.Height)
                return;

            board[point] = block;
        }

        /// <summary>
        /// Places a block at the specified location in the map.
        /// </summary>
        /// <param name="block">Block to be placed</param>
        /// <param name="x">X coordinate of the block</param>
        /// <param name="y">Y coordinate of the block</param>
        public void PlaceBlock(Board board, BoardBlock block, int x, int y)
        {
            PlaceBlock(board, block, new Point(x, y));
        }

        /// <summary>
        /// Places a house at the specified location (top left corner of the house).
        /// </summary>
        /// <param name="board">Board for the house to be placed on</param>
        /// <param name="wallBlock">Block the walls are made of</param>
        /// <param name="floorBlock">Block the floor is made of</param>
        /// <param name="x">X coordinate where the top left corner of the house will be placed</param>
        /// <param name="y">Y coordinate where the top left corner of the house will be placed</param>
        public void PlaceHouse(Board board, BoardBlock wallBlock, BoardBlock floorBlock, int x, int y)
        {
            PlaceSquare(board, floorBlock, new Point(x + 1, y + 1), 3);
            PlaceRectangle(board, wallBlock, new Point(x, y), new Point(x + 3, y + 3));
            PlaceBlock(board, floorBlock, x + 2, y);
        }

        /// <summary>
        /// Places a rectangle of blocks around the specified area
        /// </summary>
        /// <param name="board">Board for the blocks to be placed on</param>
        /// <param name="block">Block used for the rectangle</param>
        /// <param name="startingPoint">Starting point of the rectangle (upper left corner)</param>
        /// <param name="endingPoint">Ending point of the rectangle (lower right corner)</param>
        public void PlaceRectangle(Board board, BoardBlock block, Point startingPoint, Point endingPoint)
        {
            for (int i = 0; i < startingPoint.X - endingPoint.X; i++)
            {
                PlaceBlock(board, block, startingPoint.X + i, startingPoint.Y);
                PlaceBlock(board, block, startingPoint.X + i, endingPoint.Y);
            }

            for (int i = 0; i < startingPoint.Y - endingPoint.Y; i++)
            {
                PlaceBlock(board, block, startingPoint.X, startingPoint.Y + i);
                PlaceBlock(board, block, endingPoint.X, startingPoint.Y + i);
            }
        }

        /// <summary>
        /// Places a rectangle of blocks around a specified area
        /// </summary>
        /// <param name="board">Board for the blocks to be placed on</param>
        /// <param name="block">Block used for the rectangle</param>
        /// <param name="startingX">Starting X coordinate of the rectangle</param>
        /// <param name="startingY">Starting Y coordinate of the recatangle</param>
        /// <param name="endingX">Ending X coordinate of the rectangle</param>
        /// <param name="endingY">Ending Y coordinate of the rectangle</param>
        public void PlaceRectangle(Board board, BoardBlock block, int startingX, int startingY, int endingX, int endingY)
        {
            PlaceRectangle(board, block, new Point(startingX, startingY), new Point(endingX, endingY));
        }
        
        /// <summary>
        /// Places a square of blocks on the specified board.
        /// </summary>
        /// <param name="board">Board for the blocks to be placed on</param>
        /// <param name="block">Block used for the square</param>
        /// <param name="startingX">Starting X coordinate of the square (upper left corner)</param>
        /// <param name="startingY">Starting Y coordinate of the square (upper left corner)</param>
        /// <param name="sideLength">Length of each side</param>
        public void PlaceSquare(Board board, BoardBlock block, int startingX, int startingY, int sideLength)
        {
            for (int i = 0; i < sideLength; i++)
                for (int j = 0; j < sideLength; j++)
                    PlaceBlock(board, block, new Point(startingX+i, startingY+j));
        }

        /// <summary>
        /// Places a square of blocks on the specified board.
        /// </summary>
        /// <param name="board">Board for the the blocks to be placed on</param>
        /// <param name="block">Block used for the square</param>
        /// <param name="startingPoint">Starting point of the square (upper left corner)</param>
        /// <param name="sideLength">Length of each side</param>
        public void PlaceSquare(Board board, BoardBlock block, Point startingPoint, int sideLength)
        {
            PlaceSquare(board, block, startingPoint.X, startingPoint.Y, sideLength);
        }
    }
}
