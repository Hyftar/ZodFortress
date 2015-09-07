using System;
using System.Drawing;
using ZodFortress.Engine.Items;

namespace ZodFortress.Engine.Units
{
    public class Mob
    {
        public string Name { get; private set; }
        public string Text { get; private set; }
        public Point Position { get; private set; }
        public Item OffensiveSlot { get; private set; }
        public Item DefensiveSlot { get; private set; }
        public int Health { get; private set; }
        public int AttackStat { get; private set; }
        public int DefensiveStat { get; private set; }
        public char Character { get; private set; }
        public ConsoleColor FontColor { get; private set; }
        public MobType Race { get; private set; }
        public int Experience { get; private set; }

        public Mob(string name, Point position, Item offensiveItem, Item defensiveItem, int health, int attackStat, int defensiveStat, int experience, char character, ConsoleColor fontColor, MobType race)
        {
            this.Name = name;
            this.Position = position;
            this.OffensiveSlot = offensiveItem;
            this.DefensiveSlot = defensiveItem;
            this.FontColor = fontColor;
            this.Health = health;
            this.Experience = experience;
            this.Character = character;
            this.Race = race;
            this.AttackStat = attackStat;
            this.DefensiveStat = defensiveStat;
        }

        public bool Attack(int attackStrength)
        {
            this.Health -= attackStrength - (int) Math.Floor(this.DefensiveStat * this.DefensiveSlot.DefenseMultiplier);
            return this.Health < 1;
        }
    }
}
