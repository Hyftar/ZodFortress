using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodFortress.Engine.Units
{
    public class BoardUnit
    {
        public string Name { get; private set; }
        public char Character { get; private set; }
        public ConsoleColor Color { get; private set; }
        public int Health { get; private set; }
        public int DefenseStat { get; private set; }

        public BoardUnit()
        {

        }
    }
}
