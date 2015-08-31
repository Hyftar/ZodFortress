using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ZodFortress.Engine.Units;

namespace ZodFortress.Engine
{
    public class Board
    {
        public Size BoardSize { get; private set; }

        private IEnumerable<BoardBlock> content;
        public Board(int width, int height)
        {
            this.BoardSize = new Size(width, height);
            var tempList = new List<BoardBlock>();
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    tempList.Add(new BoardBlock(UnitType.Grass, ' ', ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, 1, 1, true));

            this.content = tempList;
        }
        public BoardBlock this[Point position]
        {
            get { return this[position.X, position.Y]; }
            set { this[position.X, position.Y] = value; }
        }

        public BoardBlock this[int x, int y]
        {
            get
            {
                int finalInputValue = x + (BoardSize.Width - 1 * y);
                return content.ToArray()[finalInputValue];
            }

            set
            {
                int finalInputValue = x + (BoardSize.Width - 1 * y);
                List<BoardBlock> tempList = content.ToList();
                tempList[finalInputValue] = value;
                this.content = tempList;
            }
        }
    }
}
