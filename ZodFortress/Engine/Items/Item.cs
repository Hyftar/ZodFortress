namespace ZodFortress.Engine.Items
{
    public class Item
    {
        /// <summary>
        /// Display name of the item.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Value at which a player can sell the item in a shop.
        /// </summary>
        public int SellValue { get; private set; }

        /// <summary>
        /// Value at which a player can buy the item in a shop.
        /// </summary>
        public int BuyValue { get; private set; }

        /// <summary>
        /// Attack multiplier of the item.
        /// </summary>
        public double AttackMultiplier { get; private set; }

        /// <summary>
        /// Defense multiplier of the item.
        /// </summary>
        public double DefenseMultiplier { get; private set; }

        /// <summary>
        /// The EquipSlot in which the item must be equiped in.
        /// </summary>
        public EquipSlot ItemSlot { get; private set; }

        /// <summary>
        /// Instantiates an item container.
        /// </summary>
        /// <param name="name">Name of the item</param>
        /// <param name="sellValue">Value at which a player can sell the item in a shop.</param>
        /// <param name="buyValue">Value at which a player can buy the item in a shop.</param>
        /// <param name="attackMultiplier">Attack multiplier of the item</param>
        /// <param name="defenseMultiplier">Defense multiplier of the item</param>
        /// <param name="itemSlot">The EquipSlot in which the item must be equiped in.</param>
        public Item(string name, int sellValue, int buyValue, double attackMultiplier, double defenseMultiplier, EquipSlot itemSlot)
        {
            this.Name = name;
            this.SellValue = sellValue;
            this.BuyValue = buyValue;
            this.AttackMultiplier = attackMultiplier;
            this.DefenseMultiplier = defenseMultiplier;
            this.ItemSlot = itemSlot;
        }
    }
}
