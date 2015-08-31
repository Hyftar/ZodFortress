using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZodFortress.Engine.Items;

namespace ZodFortress.Engine.Units
{
    public class Player
    {
        public bool IsAlive { get; private set; }
        public Point Position { get; private set; }
        public int DefenseStat { get; private set; }
        public int AttackStat { get; private set; }
        public int Health { get; private set; }
        public Item OffensiveSlot { get; private set; }
        public Item DefensiveSlot { get; private set; }
        public int Level { get; private set; }

        public Player(Point position)
        {
            this.IsAlive = true;
            this.Position = position;
            this.OffensiveSlot = null;
            this.DefensiveSlot = null;
            this.Health = 10;
            this.Level = 1;
            this.AttackStat = 1;
            this.DefenseStat = 1;
        }

        public bool Attack(int attackStrength)
        {
            this.Health -= attackStrength - (int) Math.Round(this.DefenseStat * this.DefensiveSlot.DefenseMultiplier);
            return this.Health < 1;
        }

        public bool Move(Board board, MovementDirection direction)
        {
            switch (direction)
            {
                case MovementDirection.Up:
                    if (this.Position.Y - 1 < 0 || this.Position.Y - 1 >= board.BoardSize.Height)
                        if (!board[this.Position.X, this.Position.Y - 1].IsWalkable)
                            return false;
                    this.Position = new Point(this.Position.X, this.Position.Y - 1);
                    return true;

                case MovementDirection.Down:
                    if (this.Position.Y + 1 < 0 || this.Position.Y + 1 >= board.BoardSize.Height)
                        if (!board[this.Position.X, this.Position.Y + 1].IsWalkable)
                            return false;
                    this.Position = new Point(this.Position.X, this.Position.Y + 1);
                    return true;

                case MovementDirection.Left:
                    if (this.Position.X - 1 < 0 || this.Position.X - 1 >= board.BoardSize.Width)
                        if (!board[this.Position.X - 1, this.Position.Y].IsWalkable)
                            return false;
                    this.Position = new Point(this.Position.X - 1, this.Position.Y);
                    return true;

                case MovementDirection.Right:
                    if (this.Position.X + 1 < 0 || this.Position.X + 1 >= board.BoardSize.Width)
                        if (!board[this.Position.X + 1, this.Position.Y].IsWalkable)
                            return false;
                    this.Position = new Point(this.Position.X + 1, this.Position.Y);
                    return true;

                default:
                    return false;
            }
        }
    }
}