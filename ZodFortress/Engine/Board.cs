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
        public Board(Size dimension, BoardBlock defaultBlock)
        {
            this.Size = dimension;
            var tempList = new List<BoardBlock>();
            for (int i = 0; i < dimension.Width; i++)
                for (int j = 0; j < dimension.Height; j++)
                    tempList.Add(defaultBlock);

            content = tempList;
        }
        public Board(int width, int height, BoardBlock defaultBlock) : this(new Size(width, height), defaultBlock) { }
        public Board(Point maxSize, BoardBlock defaultBlock) : this(new Size(maxSize), defaultBlock) { }

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
