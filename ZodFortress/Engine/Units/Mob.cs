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
        public int DefenseStat { get; private set; }
        public char Character { get; private set; }
        public ConsoleColor FontColor { get; private set; }
        public MobType Race { get; private set; }
        public int Experience { get; private set; }
        public Board CurrentBoard { get; private set; }

        public Mob(string name, Board board, Point position, Item offensiveItem, Item defensiveItem, int health, int attackStat, int defensiveStat, int experience, char character, ConsoleColor fontColor, MobType race)
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
            this.DefenseStat = defensiveStat;
        }

        /// <summary>
        /// Attacks the specified player.
        /// </summary>
        /// <param name="player">Attacked player</param>
        /// <param name="attackStrength">Strength of the attack</param>
        /// <returns>True if the attack killed the player</returns>
        public Tuple<int, bool> AttackPlayer(Player player, int attackStrength)
        {
            return Tuple.Create(player.ReceiveDamage(attackStrength + (int) Math.Floor(this.AttackStat * (this.OffensiveSlot == null ? 1 : this.OffensiveSlot.AttackMultiplier))), player.Health < 1);
        }

        /// <summary>
        /// Receives damage from a player attack.
        /// </summary>
        /// <param name="attackStrength"></param>
        /// <returns>True if the attack killed the mob</returns>
        public int ReceiveDamage(int attackStrength)
        {
            int damageReceived = attackStrength - (int)Math.Floor(this.DefenseStat * (this.DefensiveSlot == null ? 1 : this.DefensiveSlot.DefenseMultiplier));
            this.Health -= damageReceived;
            return damageReceived;
        }

        /// <summary>
        /// Moves the player in the specified direction.
        /// </summary>
        /// <param name="board">The board in which the player currently is</param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool Move(MovementDirection direction)
        {
            switch (direction)
            {
                case MovementDirection.Up:
                    if (this.Position.Y - 1 < 0 || this.Position.Y - 1 >= this.CurrentBoard.Size.Height)
                        return false;
                    if (!this.CurrentBoard[this.Position.X, this.Position.Y - 1].IsWalkable)
                        return false;
                    this.Position = new Point(this.Position.X, this.Position.Y - 1);
                    return true;

                case MovementDirection.Down:
                    if (this.Position.Y + 1 < 0 || this.Position.Y + 1 >= this.CurrentBoard.Size.Height)
                        return false;
                    if (!this.CurrentBoard[this.Position.X, this.Position.Y + 1].IsWalkable)
                        return false;
                    this.Position = new Point(this.Position.X, this.Position.Y + 1);
                    return true;

                case MovementDirection.Left:
                    if (this.Position.X - 1 < 0 || this.Position.X - 1 >= this.CurrentBoard.Size.Width)
                        return false;
                    if (!this.CurrentBoard[this.Position.X - 1, this.Position.Y].IsWalkable)
                        return false;
                    this.Position = new Point(this.Position.X - 1, this.Position.Y);
                    return true;

                case MovementDirection.Right:
                    if (this.Position.X + 1 < 0 || this.Position.X + 1 >= this.CurrentBoard.Size.Width)
                        return false;
                    if (!this.CurrentBoard[this.Position.X + 1, this.Position.Y].IsWalkable)
                        return false;
                    this.Position = new Point(this.Position.X + 1, this.Position.Y);
                    return true;

                default:
                    return false;
            }
        }
    }
}
