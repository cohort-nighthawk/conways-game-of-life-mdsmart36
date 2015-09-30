using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {
        private int rows, columns;

        private Cell[,] _currentworld;
        public Cell[,] CurrentWorld
        {
            get { return _currentworld; }
            set { _currentworld = value; }
        }

        public World(int rows, int columns)
        {
            this.rows = rows + 2;
            this.columns = columns + 2;
            this._currentworld = new Cell[this.rows, this.columns];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    this._currentworld[i, j] = new Cell();
                }
            }
            
        }
        
        public void DisplayWorld()
        {
            //int counter = 1;
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    //Console.Write(" {0} ", counter++);
                    Console.Write("{0}", (this._currentworld[i, j].IsAlive ? "1" : "0"));

                }
                Console.WriteLine();
            }
        }
    }
}
