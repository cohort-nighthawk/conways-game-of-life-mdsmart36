using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {
        private int dimension; // the size of the world; will be a perfect square

        private Cell[,] _currentworld;
        public Cell[,] CurrentWorld
        {
            get { return _currentworld; }
            set { _currentworld = value; }
        }

        public World(int dimension)
        {
            // minimum dimension is 10
            if (dimension < 10)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                // create an extra row on top and bottom so each cell has exactly 8 neighbors
                /* -- hypothetical 2 x 2 board is created as 4 x 4 board

                    3 5 5 3
                    5 8 8 5
                    5 8 8 5
                    3 5 5 3

                */
                this.dimension = dimension + 2;
                this._currentworld = new Cell[this.dimension, this.dimension];
                for (int i = 0; i < this.dimension; i++)
                {
                    for (int j = 0; j < this.dimension; j++)
                    {
                        this._currentworld[i, j] = new Cell();
                    }
                }
            }

        }
        
        // print the contents of the world to the console
        public void DisplayWorld()
        {
            for (int i = 0; i < this.dimension; i++)
            {
                for (int j = 0; j < this.dimension; j++)
                {
                    Console.Write("{0}", (this._currentworld[i, j].IsAlive ? "*" : " "));
                }
                Console.WriteLine();
            }
        }

        public void RamdomlySeedTheWorld()
        {
            Random random = new Random();
            for (int i = 0; i < this.dimension; i++)
            {
                for (int j = 0; j < this.dimension; j++)
                {
                    this._currentworld[i, j].IsAlive = random.Next(0, 2) == 0 ? false : true;
                }
                
            }
        }

        public void SeedWithBlinkers()
        {
            for (int i = 0; i < 3; i++)
            {
                this._currentworld[3, 3 + i].IsAlive = true;
                this._currentworld[8, 8 + i].IsAlive = true;
            }
        }

        public void SeedWithToad()
        {
            for (int i = 0; i < 3; i++)
            {
                this._currentworld[3, 3 + i].IsAlive = true;
                this._currentworld[4, 2 + i].IsAlive = true;

                this._currentworld[8, 8 + i].IsAlive = true;
                this._currentworld[9, 7 + i].IsAlive = true;
            }
        }

        public void SeedWithGlider()
        {
            this._currentworld[1, 4].IsAlive = true;
            this._currentworld[2, 5].IsAlive = true;
            for (int i = 0; i < 3; i++)
            {
                this._currentworld[3, 3 + i].IsAlive = true;
            }
        }

        public void SeedWithFourLevelPyramid()
        {
            //            *
            //           ***
            //          *****

            // position of top
            int firstX = 5;
            int firstY = 10;

            // top cell
            this._currentworld[firstX, firstY].IsAlive = true;

            // second row
            for (int i = 0; i < 3; i++)
            {
                this._currentworld[firstX + 1, i + (firstY - 1)].IsAlive = true;
            }

            // third row
            for (int i = 0; i < 5; i++)
            {
                this._currentworld[firstX + 2, i + (firstY - 2)].IsAlive = true;
            }

            // fourth row
            for (int i = 0; i < 7; i++)
            {
                this._currentworld[firstX + 3, i + (firstY - 3)].IsAlive = true;
            }

            // bottom (if you want to add a mirror image)
        }

        public void SeedWithSquare(int XPos, int YPos, int dimension)
        {
            // check for errors in the parameters
            // if X or Y coordinate of top-left corner of square out of range
            if ((XPos < 0 || XPos > this.dimension) || (YPos < 0 | YPos > this.dimension))
            {
                throw new ArgumentOutOfRangeException();
            }

            // if height or width is too large
            if ((XPos + dimension > this.dimension) || (YPos + dimension > this.dimension))
            {
                throw new ArgumentOutOfRangeException();
            }

            // if dimension is too small
            if (dimension < 2)
            {
                throw new ArgumentOutOfRangeException();
            }

            // create a square on the board
            for (int i = XPos; i < XPos + dimension; i++)
            {
                for (int j = YPos; j < YPos + dimension; j++)
                {
                    if (i == XPos || i == XPos + dimension - 1 || j == YPos || j == YPos + dimension - 1)
                    {
                        this._currentworld[i, j].IsAlive = true;
                    }

                }
            }
        }

        public int CountAliveNeighbors(int i, int j)
        {
            // each cell in the world has exactly 8 neighbors by definition

            int aliveNeighbors = 0;
            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    // calculate number of alive neighbors
                    if (k == i && l == j)
                    {
                        /* center cell, so ignore */
                    }
                    else
                    {
                        // check all eight neighbors to see if they are alive
                        if (this._currentworld[k, l].IsAlive)
                        {
                            aliveNeighbors++;
                        }
                    }
                }
            }
            return aliveNeighbors;
        }

        public bool DetermineNextGeneration(bool cellIsAlive, int aliveNeighbors)
        {
            if (cellIsAlive)
            {
                if (aliveNeighbors < 2 || aliveNeighbors > 3)
                { return false; } // cell dies from underpopulation or overpopulation
                return true; // cell lives by optimal conditions
            }
            else
            {
                if (aliveNeighbors == 3) { return true; } // cell lives as if by reproduction
                return false; // cell remains dead
            }
        }

        public void ApplyTheRulesOfTheGame()
        {
            int aliveNeighbors;
            // loop through all the cells in the world, but only test the cells that are 1+ row from the edge
            int edge = this.dimension - 1;
            for (int i = 1; i < edge; i++)
            {
                for (int j = 1; j < edge; j++)
                {
                    aliveNeighbors = CountAliveNeighbors(i, j);

                    // apply rules here and set value for next generation
                    /*
                    1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
                    2. Any live cell with two or three live neighbours lives on to the next generation.
                    3. Any live cell with more than three live neighbours dies, as if by overcrowding.
                    4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                    */

                    // if cell.IsAlive && aliveNeighbors < 2 or > 3, then newWorld[i,j].IsAlive = false;
                    // if cell.IsAlive && aliveNeibors > 1 and < 4, then newWorld[i,j].IsAlive = true;
                    // if !cell.IsAlive && aliveNeighbors == 3, then newWorld[i,j].IsAlive = true;

                    this._currentworld[i, j].NextGeneration = DetermineNextGeneration(this._currentworld[i, j].IsAlive, aliveNeighbors);

                }
            }
            // update the currentworld to reflect the next generation
            for (int i = 0; i < this.dimension; i++)
            {
                for (int j = 0; j < this.dimension; j++)
                {
                    this._currentworld[i, j].IsAlive = this._currentworld[i, j].NextGeneration;
                }
                Console.WriteLine();
            }
        }
    }
}
