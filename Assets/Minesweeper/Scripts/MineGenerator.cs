using System;

namespace Minesweeper
{
    public static class MineGenerator
    {
        public static bool[,] Generate(int gridSize, int minesCount)
        {
            if (minesCount <= 0)
            {
                throw new System.ArgumentOutOfRangeException("MineCount can not be less or equal than zero");
            }
            else if (minesCount >= (gridSize * gridSize))
            {
                throw new System.ArgumentOutOfRangeException("MineCount can not be more or equal than GridSize*GridSize");
            }

            bool[,] mines = new bool[gridSize, gridSize];

            int iter = minesCount;
            for(int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    mines[i, j] = iter > 0 ? true : false;
                    iter--;
                }
            }

            Random rng = new Random();
            int rows = gridSize;
            int cols = gridSize;

            for (int i = rows * cols - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);

                int currentRow = i / cols;
                int currentCol = i % cols;
                int randomRow = j / cols;
                int randomCol = j % cols;

                bool temp = mines[currentRow, currentCol];
                mines[currentRow, currentCol] = mines[randomRow, randomCol];
                mines[randomRow, randomCol] = temp;
            }

            return mines;
        }
    }
}

