using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using ZodFortress;
using ZodFortress.Engine;
using ZodFortress.Engine.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZodFortressUnitTest
{
    [TestClass]
    public class PlayerExperienceTest
    {
        private Map map;
        private Player player;
        private Mob mob;

        [TestInitialize]
        public void TestInitializer()
        {

            Trace.WriteLine("Creating default map...");
            map = new Map(new Size(100, 100), 1, MapGenerator.Grass);

            Trace.WriteLine("Creating default player...");
            player = new Player(map.Layers.First(), new Point(50, 50));

            Trace.WriteLine("Creating default mob...");
            mob = new Mob("TestMob", map.Layers.First(), new Point(1, 1), null, null, 2, 1, 0, 15, 'M', ConsoleColor.Black, MobType.Orc);

            Assert.IsInstanceOfType(map, typeof(Map), "Failed to initialize the map.");
            Assert.IsInstanceOfType(player, typeof(Player), "Failed to initiaze the player.");
            Assert.IsInstanceOfType(mob, typeof(Mob), "Failed to initialize the mob.");
        }

        [TestMethod]
        public void ExpToNextLevel()
        {
            Trace.WriteLine("Creating default map...");
            Trace.WriteLine("Creating player...");
            Trace.WriteLine("Giving 130 experience to the player...");
            player.GiveExperience(130);
            Trace.WriteLine(string.Format("The player is currently level {0}, has {1} exp, {2} HP, {3} attack, {4} defense.", 
                player.Level, 
                player.Experience, 
                player.Health, 
                player.AttackStat, 
                player.DefenseStat));
            Assert.AreEqual(6, player.Level);
        }
    }
}
