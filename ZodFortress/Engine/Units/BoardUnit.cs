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
        public ConsoleColor FontColor { get; private set; }
        public ConsoleColor BackColor { get; private set; }
        public int Health { get; private set; }
        public int DefenseStat { get; private set; }

        public BoardUnit(string name, char character, ConsoleColor backColor, ConsoleColor fontColor, int health, int defenseStat)
        {
            this.Name = name;
            this.Character = character;
            this.FontColor = fontColor;
            this.BackColor = backColor;
            this.Health = health;
            this.DefenseStat = defenseStat;
        }

        public bool Attack(int attackStrength)
        {
            this.Health -= attackStrength - DefenseStat;
            return Health < 1;
        } 
    }
}
