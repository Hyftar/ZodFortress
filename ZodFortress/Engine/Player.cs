using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZodFortress.Engine.Items;

namespace ZodFortress.Engine
{
    public class Player
    {
        public bool IsAlive { get; private set; }
        public Point Position { get; private set; }
        public int DefenseStat { get; private set; }
        public int AttackStat { get; private set; }
        public int Health { get; private set; }
        public Item OffensiveSlot { get; private set; }
        public int Level { get; private set; }

        public bool Attack(int attackStrength)
        {
            this.Health -= attackStrength - this.DefenseStat;
            return this.Health < 1;
        }
    }
}