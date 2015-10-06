using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        // is this cell currently alive? T or F
        private bool isAlive;
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        // will this cell be alive in the next tick? T or F
        private bool nextGeneration;
        public bool NextGeneration
        {
            get { return nextGeneration; }
            set { nextGeneration = value; }
        }


        public Cell()
        {
            // cell will be dead by default
            this.isAlive = false;
            this.nextGeneration = false;
        }

    }
}
