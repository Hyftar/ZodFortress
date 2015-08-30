using System;
using ZodFortress;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZodFortressUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ZodFortress.Engine.MapGenerator mapg = new ZodFortress.Engine.MapGenerator();
            mapg.Generate();
            
        }
    }
}
