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
        public Board CurrentBoard { get; set; }
        public bool IsAlive { get; private set; }
        public Point Position { get; private set; }
        public int DefenseStat { get; private set; }
        public int AttackStat { get; private set; }
        public int Health { get; private set; }
        public Item OffensiveSlot { get; private set; }
        public Item DefensiveSlot { get; private set; }
        public List<Item> Inventory { get; private set;}
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

        /// <summary>
        /// Attacks the player with the specified strength.
        /// </summary>
        /// <param name="attackStrength">Strength of the attack</param>
        /// <returns>True if the attack is lethal to the player</returns>
        public bool Attack(int attackStrength)
        {
            this.Health -= attackStrength - (int) Math.Floor(this.DefenseStat * this.DefensiveSlot.DefenseMultiplier);
            return this.Health < 1;
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
                        if (!this.CurrentBoard[this.Position.X, this.Position.Y - 1].IsWalkable)
                            return false;
                    this.Position = new Point(this.Position.X, this.Position.Y - 1);
                    return true;

                case MovementDirection.Down:
                    if (this.Position.Y + 1 < 0 || this.Position.Y + 1 >= this.CurrentBoard.Size.Height)
                        if (!this.CurrentBoard[this.Position.X, this.Position.Y + 1].IsWalkable)
                            return false;
                    this.Position = new Point(this.Position.X, this.Position.Y + 1);
                    return true;

                case MovementDirection.Left:
                    if (this.Position.X - 1 < 0 || this.Position.X - 1 >= this.CurrentBoard.Size.Width)
                        if (!this.CurrentBoard[this.Position.X - 1, this.Position.Y].IsWalkable)
                            return false;
                    this.Position = new Point(this.Position.X - 1, this.Position.Y);
                    return true;

                case MovementDirection.Right:
                    if (this.Position.X + 1 < 0 || this.Position.X + 1 >= this.CurrentBoard.Size.Width)
                        if (!this.CurrentBoard[this.Position.X + 1, this.Position.Y].IsWalkable)
                            return false;
                    this.Position = new Point(this.Position.X + 1, this.Position.Y);
                    return true;

                default:
                    return false;
            }
        }

        public void EquipItem(Item item, EquipSlot slot)
        {
            switch (slot)
            {
                case EquipSlot.Attack:
                    this.Inventory.Remove(item);
                    this.Inventory.Add(this.OffensiveSlot);
                    this.OffensiveSlot = item;
                    return;
                case EquipSlot.Defense:
                    this.Inventory.Remove(item);
                    this.Inventory.Add(this.DefensiveSlot);
                    this.DefensiveSlot = item;
                    return;
            }
        }
    }
}