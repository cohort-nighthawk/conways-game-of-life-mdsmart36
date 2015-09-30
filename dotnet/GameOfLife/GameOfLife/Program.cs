using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            World myWorld = new World(10, 10);
            myWorld.CurrentWorld[0, 0].IsAlive = true;
            myWorld.DisplayWorld();
            Console.ReadLine();
        }
    }
}
