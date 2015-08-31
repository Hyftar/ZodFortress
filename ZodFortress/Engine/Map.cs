using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodFortress.Engine
{
    public class Map
    {
        private readonly Board[] layers;
        public IEnumerable<Board> Layers { get { return this.layers; } }
        public int Depth { get; private set; }

        public Units.BoardBlock this[int x, int y, int z]
        {
            get { return this.layers[z][x, y]; }
            set { this.layers[z][x, y] = value; }
        }

        public Map(int width, int height, int depth)
        {
            if (depth < 0)
                throw new ArgumentOutOfRangeException("depth");

            if (depth == 0)
                throw new ArgumentException("depth");

            this.layers = Enumerable.Range(0, depth).Select(x => new Board(width, height)).ToArray();
        }
    }
}
