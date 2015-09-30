using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTest
{
    [TestClass]
    public class UnitTestWorld
    {
        [TestMethod]
        public void TestWorldConstructorDefault()
        {
            World myWorld = new World(10, 10);
            Assert.IsFalse(myWorld.CurrentWorld[0, 0].IsAlive);
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
