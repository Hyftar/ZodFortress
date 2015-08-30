using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodFortress.Engine
{
    public class Map
    {
        public IEnumerable<Board> Height { get; private set; }
        public int MaxDepth { get; private set; }

        public Map(int width, int height, int depth)
        {
            this.MaxDepth = depth;
            var boards = new List<Board>();

            for (int i = 0; i < depth; ++i)
                boards.Add(new Board(width, height));
            Height = boards;
        }
    }
}
