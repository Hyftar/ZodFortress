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
            System.Diagnostics.Trace.WriteLine("Creating default map...");
            var map = new Map(new Size(100, 100), 1, MapGenerator.Grass);
            System.Diagnostics.Trace.WriteLine("Generating terrain...");
            var mapg = new MapGenerator(map);
            mapg.Generate(map.Layers.First());

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

            System.Diagnostics.Trace.WriteLine(string.Format("Generated {0} grass, {1} trees, {2} rocks. Total: {3}.", grass, trees, rocks, total));
        }
    }
}
