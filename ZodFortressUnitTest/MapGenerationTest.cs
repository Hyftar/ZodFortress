using System;
using System.Linq;
using System.Drawing;
using ZodFortress.Engine;
using ZodFortress.Engine.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZodFortressUnitTest
{
    [TestClass]
    public class MapGenerationTest
    {
        /// <summary>
        /// Asserts that the map is populated with board blocks by default
        /// </summary>
        [TestMethod]
        public void GenerateDefaultMap()
        {
            var map = new Map(1, 100, 100);
            var mapg = new MapGenerator(map);
            mapg.Generate(map[0]);

            for (int i = 0; i < map[0].Size.Width; i++)
                for (int j = 0; j < map[0].Size.Height; j++)
                    Assert.IsTrue(map[i, j, 0] is BoardBlock);
        }
    }
}
