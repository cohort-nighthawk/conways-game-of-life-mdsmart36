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
            World myWorld = new World(15);
            myWorld.RamdomlySeedTheWorld();
            myWorld.DisplayWorld();
            Console.ReadLine();
        }
    }
}
