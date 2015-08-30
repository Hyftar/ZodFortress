using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodFortress;
using ZodFortress.Engine;

namespace ZodFortress.Engine
{
    public class Board
    {
        public Size BoardSize { get; private set; }

        private IEnumerable<Units.BoardUnit> content;
        public Board(int width, int height)
        {
            this.BoardSize = new Size(width, height);
            this.content = new List<Units.BoardUnit>();
        }

        public Units.BoardUnit this[int x, int y]
        {
            get
            {
                int finalInputValue = x + BoardSize.Width * y;
                return content.ToArray()[finalInputValue];
            }

            set
            {
                int finalInputValue = x + BoardSize.Width * y;
                List<Units.BoardUnit> tempList = content.ToList();
                tempList[finalInputValue] = value;
                this.content = tempList;
            }
        }
    }
}
