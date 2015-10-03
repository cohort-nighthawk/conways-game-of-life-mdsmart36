using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        private bool isAlive;
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        private bool nextGeneration;
        public bool NextGeneration
        {
            get { return nextGeneration; }
            set { nextGeneration = value; }
        }


        public Cell()
        {
            this.isAlive = false;
            this.nextGeneration = false;
        }

    }
}
