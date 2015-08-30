using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ZodFortress.Engine
{
    public class Player
    {
        public bool IsAlive { get; private set; }
        public Point Position { get; private set; }
    }
}