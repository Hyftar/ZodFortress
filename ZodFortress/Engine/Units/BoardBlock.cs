using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodFortress.Engine.Units
{
    public class BoardBlock
    {
        public UnitType Type { get; private set; }
        public char Character { get; private set; }
        public ConsoleColor FontColor { get; private set; }
        public ConsoleColor BackColor { get; private set; }
        public int Health { get; private set; }
        public int DefenseStat { get; private set; }
        public bool IsWalkable { get; private set; }

        public BoardBlock(UnitType type, char character, ConsoleColor backColor, ConsoleColor fontColor, int health, int defenseStat, bool isWalkable)
        {
            this.Type = type;
            this.Character = character;
            this.FontColor = fontColor;
            this.BackColor = backColor;
            this.Health = health;
            this.DefenseStat = defenseStat;
            this.IsWalkable = isWalkable;
        }

        public bool Attack(int attackStrength)
        {
            this.Health -= attackStrength - DefenseStat;
            return Health < 1;
        } 
    }
}
