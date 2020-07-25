using System;
using System.Collections.Generic;

namespace CodilityTasks.Tasks
{
    public class ExampleTasks
    {
        public static int Example1(int[] arr, int x)
        {
            int n = arr.Length;

            int xCount = 0;
            int[] xCounts = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == x)
                    xCount++;
                xCounts[i] = xCount;
            }

            int notXCount = 0;
            for (int i = n; i > 0; i--)
            {
                if (arr[i - 1] != x)
                    notXCount++;
                if (notXCount > xCounts[i - 1])
                    return i;
            }
            return 0;
        }

        public static int LeastNumOfKnightSteps(int x0, int y0, int xN, int yN)
        {
            var passedCells = new HashSet<Cell>();
            var start = new Cell(x0, y0);
            var target = new Cell(xN, yN);

            var xSteps = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
            var ySteps = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };

            return CountSteps(new List<Cell> { start }, target, 0,
                new HashSet<Cell>(), xSteps, ySteps);
        }

        static int CountSteps(List<Cell> startCells, Cell target, int stepsCount, 
            ISet<Cell> passedCells, int[] xSteps, int[] ySteps)
        {
            Console.WriteLine("Итерация " + (stepsCount + 1));
            var nextStartCells = new List<Cell>();
            foreach (Cell start in startCells)
            {
                Console.WriteLine(string.Format("Стартовая точка ({0}, {1})", start.x, start.y));
                if (start.Equals(target))
                    return stepsCount;
                for (int i = 0; i < 8; i++)
                {
                    var cell = new Cell(start.x + xSteps[i], start.y + ySteps[i]);
                    Console.WriteLine(string.Format("Ход: ({0}, {1}) -> ({2}, {3})", start.x, start.y, cell.x, cell.y));
                    if (cell.Equals(target))
                        return stepsCount + 1;
                    if (passedCells.Contains(cell))
                        continue;
                    passedCells.Add(cell);
                    nextStartCells.Add(cell);
                }
            }
            return CountSteps(nextStartCells, target, stepsCount + 1, passedCells, xSteps, ySteps);
        }
    }

    class Cell
    {
        public int x { get; }
        public int y { get; }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            Cell that = (Cell)obj;
            return x == that.x && y == that.y;
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }
    }
}
