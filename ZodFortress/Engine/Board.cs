using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodFortress;
using ZodFortress.Engine;
using ZodFortress.Engine.Units;

namespace ZodFortress.Engine
{
    public class Board
    {
        public Size BoardSize { get; private set; }

        private IEnumerable<Units.BoardUnit> content;
        public Board(int width, int height)
        {
            this.BoardSize = new Size(width, height);
            var tempList = new List<Units.BoardUnit>();
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    tempList.Add(new BoardUnit(Units.UnitType.Grass, ' ', ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, 1, 1, true));
            this.content = tempList;

        }
        public BoardUnit this[Point position]
        {
            get { return this[position.X, position.Y]; }
            set { this[position.X, position.Y] = value; }
        }

        public BoardUnit this[int x, int y]
        {
            get
            {
                int finalInputValue = x + (BoardSize.Width - 1 * y);
                return content.ToArray()[finalInputValue];
            }

            set
            {
                int finalInputValue = x + (BoardSize.Width - 1 * y);
                List<Units.BoardUnit> tempList = content.ToList();
                tempList[finalInputValue] = value;
                this.content = tempList;
            }
        }
    }
}
