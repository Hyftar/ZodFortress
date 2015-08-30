using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodFortress.Engine.Items
{
    public class Item
    {
        public string Name { get; private set; }
        public int SellValue { get; private set; }
        public int BuyValue { get; private set; }
        public float AttackMultiplier { get; private set; }
        public float DefenseMultiplier { get; private set; }
        public EquipSlot ItemSlot { get; private set; }

        public Item(string name, int sellValue, int buyValue, float attackMultiplier, float defenseMultiplier, EquipSlot itemSlot)
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
