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
            World myWorld = new World(10);
            Assert.IsFalse(myWorld.CurrentWorld[0, 0].IsAlive);
            Assert.IsFalse(myWorld.CurrentWorld[0, 0].NextGeneration);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMinimumWorldSize()
        {
            World myWorld = new World(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSeedWithSquare1()
        {
            // test correct first parameter
            World myWorld = new World(10);
            myWorld.SeedWithSquare(-1, 5, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSeedWithSquare2()
        {
            // test correct second parameter
            World myWorld = new World(10);
            myWorld.SeedWithSquare(1, -5, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSeedWithSquare3()
        {
            // test correct third parameter
            World myWorld = new World(10);
            myWorld.SeedWithSquare(5, 5, 20);
        }
    }
}
