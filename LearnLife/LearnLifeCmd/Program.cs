using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnLifeCmd
{
    class Program
    {
        static void Main(string[] args)
		{
			LearnLifeCore.Grid grid = new LearnLifeCore.Grid(Console.WindowWidth - 1, Console.WindowHeight - 5);
			grid.RandomWorld(10);

			/*
			 * TODO
			 * 
			 * Key handler
			 * h, ?, help, man - help
			 * i - info
			 * l - load
			 * 
			 * File Loader
			 * 
			 * cmd path: System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
			 */

			do
            {
				Console.Clear();
                RenderNext(grid);
                grid.GenerateNext();
            } while (Console.ReadKey().Key == ConsoleKey.Enter);            
        }

        static void RenderNext(LearnLifeCore.Grid grid)
        {
            Console.WriteLine("Gen: {0}", grid.Generation);
            for (int j = 0; j < grid.Height; j++)
            {
                for (int i = 0; i < grid.Width; i++)
                {
                    if (grid[i, j] == 1) Console.Write("#");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
