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
        public int MapHeight { get; private set; }

        public Map(int height, int width, int depth)
        {
        }
    }
}
