﻿using System;
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
            World myWorld = new World(20);
            //myWorld.RamdomlySeedTheWorld();
            //myWorld.SeedWithBlinkers();
            //myWorld.SeedWithToad();
            myWorld.SeedWithGlider();
            //myWorld.SeedWithFourLevelPyramid();
            myWorld.SeedWithSquare(2, 2, 10);

            myWorld.DisplayWorld();
            Console.WriteLine(" -- SEED--");
            Console.ReadLine();
            
            for (int i = 0; i < 60; i++)
            {
                myWorld.ApplyTheRulesOfTheGame();
                myWorld.DisplayWorld();
                Console.WriteLine("Generation {0}", i + 1);
                //Console.ReadLine();
                System.Threading.Thread.Sleep(750);
            }

            Console.ReadLine();
        }
    }
}
