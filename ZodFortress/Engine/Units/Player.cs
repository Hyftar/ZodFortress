using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Item> Inventory { get; private set; }
        public int Level { get; private set; }
        public int Experience { get; private set; }

        public readonly int[] ExperienceChart = new int[100];

        public Player(Board board, Point position)
        {
            this.CurrentBoard = board;
            this.IsAlive = true;
            this.Position = position;
            this.Health = 10;
            this.Level = 1;
            this.AttackStat = 1;
            this.DefenseStat = 1;
            int index = 1;
            ExperienceChart = ExperienceChart.Select(x => (int)Math.Round(Math.Log(Math.Pow(index, 2)) * Math.Pow(index++, 2))).ToArray();       
        }

        /// <summary>
        /// Attacks the specified mob
        /// </summary>
        /// <param name="mob"></param>
        /// <param name="attackStrength"></param>
        /// <returns>Tuple containing the amount of damage dealt to the mob and if the attack killed the mob or not</returns>
        public Tuple<int, bool> AttackMob(Mob mob, int attackStrength)
        {
            return Tuple.Create(mob.ReceiveDamage(attackStrength + (int)Math.Floor(this.AttackStat * (this.OffensiveSlot == null ? 1 : this.OffensiveSlot.AttackMultiplier))), mob.Health < 1);
        }

        /// <summary>
        /// Attacks the player with the specified strength.
        /// </summary>
        /// <param name="attackStrength">Strength of the attack</param>
        /// <returns>The amnount of damage dealt to the player.</returns>
        public int ReceiveDamage(int attackStrength)
        {
            int damageReceived = attackStrength - (int)Math.Floor(this.DefenseStat * this.DefensiveSlot.DefenseMultiplier);
            this.Health -= damageReceived;
            return damageReceived;
        }

        /// <summary>
        /// Moves the player in the specified direction.
        /// </summary>
        /// <param name="board">The board in which the player currently is</param>
        /// <param name="direction"></param>
        /// <returns>If the player was able to move at that space or not</returns>
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

        /// <summary>
        /// Equips an item on the specified item slot.
        /// </summary>
        /// <param name="item">Item to be equiped</param>
        /// <param name="slot">Slot in which the item will be equiped</param>
        public void EquipItem(Item item, EquipSlot slot)
        {
            if (!this.Inventory.Contains(item)) return;
            var equipSlot = slot == EquipSlot.Attack ? this.OffensiveSlot : this.DefensiveSlot;
            this.Inventory.Remove(item);
            this.Inventory.Add(equipSlot);
            equipSlot = item;
        }

        /// <summary>
        /// Awards experience to the player and level him up if needed
        /// </summary>
        /// <param name="experience">Amount of experience to be awarded</param>
        public void GiveExperience(int experience)
        {
            this.Experience += experience;
            int currentLevel = this.Level;
            int expectedLevel = 0;

            // Checks if the player should be higher level and levels the player if needed.
            foreach (var item in ExperienceChart)
                if (this.Experience < item)
                    break;
                else
                    ++expectedLevel;
            for (int i = 0; i < expectedLevel - currentLevel; i++)
                LevelUp();
        }

        private void LevelUp()
        {
            this.Level++;
            this.AttackStat++;
            this.DefenseStat++;
            this.Health += 5;
        }
    }
}