using System;

namespace Problem15
{
    // Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

    // How many such routes are there through a 20×20 grid?
    class Program
    {
        static void Main(string[] args)
        {
            const int gridSize = 20;
            // There are 20 paths down each side but each path as 21 boundary points
            long[,] grid = new long[gridSize + 1, gridSize + 1];

            //Initialise the grid with boundary conditions, intially each path is worth 1
            for (int i = 0; i < gridSize; i++)
            {
                grid[i, gridSize] = 1; grid[gridSize, i] = 1;
            }

            // We now cycle through each point and determine the amount of paths for each point
            // starting at the end point and working back to the beginning
            // https://www.mathblog.dk/project-euler-15/
            for (int i = gridSize - 1; i >= 0; i--)
            {
                for (int j = gridSize - 1; j >= 0; j--)
                {
                    grid[i, j] = grid[i + 1, j] + grid[i, j + 1];
                }
            }

            // We now pick the first grid which has the value of possible paths from the first point
            Console.Write("Problem 15: ");
            Console.WriteLine("The result is " + grid[0, 0]);
            Console.ReadLine();
        }
    }
}
