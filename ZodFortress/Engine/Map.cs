using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodFortress.Engine
{
    public class Map
    {
        public IEnumerable<Board> Depth { get; private set; }
        public int MaxDepth { get; private set; }

        public Units.BoardBlock this[int x, int y, int z]
        {
            get { return Enumerable.Skip(this.Depth, z).First()[x, y]; }
            set { Enumerable.Skip(this.Depth, z).First()[x, y] = value; }
        }

        public Map(int width, int height, int depth)
        {
            this.MaxDepth = depth;
            var boards = new List<Board>();

            for (int i = 0; i < depth; ++i)
                boards.Add(new Board(width, height));
            this.Depth = boards;
        }
    }
}
