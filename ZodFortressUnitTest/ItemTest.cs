using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using ZodFortress;
using ZodFortress.Engine;
using ZodFortress.Engine.Items;
using ZodFortress.Engine.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZodFortressUnitTest
{
    [TestClass]
    public class ItemTest
    {
        private Map map;
        private Player player;
        private Item sword;

        [TestInitialize]
        public void TestInitializer()
        {
            Trace.WriteLine("Creating default map...");
            map = new Map(new Size(5, 5), 1, MapGenerator.Grass);

            Trace.WriteLine("Creating default player...");
            player = new Player(map.Layers.First(), new Point(5));

            Trace.WriteLine("Creating default mob...");
            sword = new Item("Test sword", 5, 10, 1.5, 1, EquipSlot.Attack);

            Assert.IsInstanceOfType(map, typeof(Map), "Failed to initialize map.");
            Assert.IsInstanceOfType(player, typeof(Player), "Failed to initialize player.");
            Assert.IsInstanceOfType(sword, typeof(Item), "Failed to initialize item.");
        }

        [TestMethod]
        public void EquipItem()
        {
            Trace.WriteLine(string.Format("Adding {0} to inventory.", sword.Name));
            player.Inventory.Add(sword);
            Assert.IsTrue(player.Inventory.Any(), "Failed to add item to inventory.");

            Trace.WriteLine(string.Format("Adding {0} to offensive slot.", sword.Name));
            player.EquipItem(player.Inventory.First(), EquipSlot.Attack);
            Assert.IsTrue(player.Inventory.Any(), "Failed to remove item from player's inventory.");
            Assert.IsInstanceOfType(player.OffensiveSlot, typeof(Item), "Failed to add item to player's offensive slot.");
        }
    }
}
