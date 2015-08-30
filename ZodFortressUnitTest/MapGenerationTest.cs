using System;
using System.Linq;
using System.Drawing;
using ZodFortress;
using ZodFortress.Engine.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZodFortressUnitTest
{
    [TestClass]
    public class MapGenerationTest
    {
        [TestMethod]
        public void GenerateDefaultMap()
        {
            ZodFortress.Engine.MapGenerator mapg = new ZodFortress.Engine.MapGenerator();
            mapg.Generate();
            //for (int i = 0; i < mapg.mainBoard.Depth.First().BoardSize.Width; i++)
            //    for (int j = 0; j < mapg.mainBoard.Depth.First().BoardSize.Height; j++)
            //        Assert.IsTrue(mapg.mainBoard[i, j, 0] is BoardUnit);
        }
    }
}
