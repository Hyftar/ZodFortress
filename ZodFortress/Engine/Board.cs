using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ZodFortress.Engine.Units;

namespace ZodFortress.Engine
{
    public class Board
    {
        public Size Size { get; private set; }

        private IEnumerable<BoardBlock> content;
        public Board(Size dimension)
        {
            this.Size = dimension;
            var tempList = new List<BoardBlock>();
            for (int i = 0; i < dimension.Width; i++)
                for (int j = 0; j < dimension.Height; j++)
                    tempList.Add(new BoardBlock(UnitType.Grass, ' ', ConsoleColor.Black, ConsoleColor.DarkGreen, 1, 1, true));
        }
        public Board(int width, int height) : this(new Size(width, height)) { }
        public Board(Point maxSize) : this(new Size(maxSize)) { }

        public BoardBlock this[Point position]
        {
            get { return this[position.X, position.Y]; }
            set { this[position.X, position.Y] = value; }
        }

        public BoardBlock this[int x, int y]
        {
            get
            {
                int finalInputValue = x + (Size.Width - 1 * y);
                return content.ToArray()[finalInputValue];
            }

            set
            {
                int finalInputValue = x + (Size.Width - 1 * y);
                List<BoardBlock> tempList = content.ToList();
                tempList[finalInputValue] = value;
                this.content = tempList;
            }
        }
    }
}
