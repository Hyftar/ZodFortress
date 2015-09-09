using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using ZodFortress.Engine;
using ZodFortress.Engine.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZodFortressUnitTest
{
    [TestClass]
    public class MapGenerationTest
    {
        private Map map;
        private MapGenerator mapGen;

        [TestInitialize]
        public void TestInitializer()
        {
            Trace.WriteLine("Creating default map...");
            map = new Map(new Size(100, 100), 1, MapGenerator.Grass);

            Trace.WriteLine("Generating terrain...");
            mapGen = new MapGenerator(map);

            Assert.IsInstanceOfType(map, typeof(Map), "Failed to initialize map.");
            Assert.IsInstanceOfType(mapGen, typeof(MapGenerator), "Failed to initialize the map generator.");
        }
        /// <summary>
        /// Asserts that the map is populated with board blocks by default
        /// </summary>
        [TestMethod]
        public void GenerateDefaultMap()
        {

            mapGen.Generate(map.Layers.First());

            int trees = 0;
            int grass = 0;
            int rocks = 0;
            int total = 0;

            for (int i = 0; i < map[0].Size.Width; i++)
            {
                for (int j = 0; j < map[0].Size.Height; j++)
                {
                    Assert.IsTrue(map[i, j, 0] is BoardBlock);
                    if (map[i, j, 0] == MapGenerator.Rock)
                        ++rocks;
                    else if (map[i, j, 0] == MapGenerator.Grass)
                        ++grass;
                    else if (map[i, j, 0] == MapGenerator.Tree)
                        ++trees;
                    ++total;
                }
            }

            Trace.WriteLine(string.Format("Generated {0} grass, {1} trees, {2} rocks. Total: {3}.", grass, trees, rocks, total));
        }
    }
}
