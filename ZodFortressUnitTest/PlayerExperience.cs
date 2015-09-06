using System;
using System.Drawing;
using System.Linq;
using ZodFortress;
using ZodFortress.Engine;
using ZodFortress.Engine.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZodFortressUnitTest
{
    [TestClass]
    public class PlayerExperience
    {
        [TestMethod]
        public void ExpToNextLevel()
        {
            System.Diagnostics.Trace.WriteLine("Creating default map...");
            var testMap = new Map(new Size(100, 100), 1, MapGenerator.Grass);
            System.Diagnostics.Trace.WriteLine("Creating player...");
            var testPlayer = new Player(testMap.Layers.First(), new Point(50, 50));
            System.Diagnostics.Trace.WriteLine("Giving 130 experience to the player...");
            testPlayer.GiveExperience(130);
            System.Diagnostics.Trace.WriteLine(string.Format("The player is currently level {0}, has {1} exp, {2} HP, {3} attack, {4} defense.", 
                testPlayer.Level, 
                testPlayer.Experience, 
                testPlayer.Health, 
                testPlayer.AttackStat, 
                testPlayer.DefenseStat));
            Assert.AreEqual(6, testPlayer.Level);
        }
    }
}
