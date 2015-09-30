using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTest
{
    [TestClass]
    public class UnitTestCell
    {
        [TestMethod]
        public void TestDefaultCellState()
        {
            Cell myCell = new Cell();
            Assert.IsFalse(myCell.IsAlive);
        }

        [TestMethod]
        public void TestSetCellSetStatus()
        {
            Cell myCell = new Cell();
            myCell.IsAlive = true;
            Assert.IsTrue(myCell.IsAlive);
        }

        
    }
}
