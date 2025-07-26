using System;
using System.Collections.Generic;
using System.Text;
using Zenject;

namespace Minesweeper
{
    public class GameController : IInitializable
    {
        public event Action<int, int, int, bool> OnCellOpened = null;

        private Cell[,] _cells = null;
        private int _gridSize = 10;
        private int _minesCount = 10;

        public GameController(int gridSize, int minesCount)
        {
            _gridSize = gridSize;
            _minesCount = minesCount;
        }

        public void Initialize()
        {
            _cells = new Cell[_gridSize, _gridSize];

            bool[,] mines = MineGenerator.Generate(_gridSize, _minesCount);

            for (int j = 0; j < _gridSize; j++)
            {
                for (int i = 0; i < _gridSize; i++)
                {
                    bool isMine = mines[i, j];
                    _cells[i, j] = new Cell(isMine);
                }
            }

            List<Cell> neighbors;
            for (int j = 0; j < _gridSize; j++)
            {
                for (int i = 0; i < _gridSize; i++)
                {
                    neighbors = new List<Cell>();
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        for (int di = -1; di <= 1; di++)
                        {
                            if (di == 0 && dj == 0)
                                continue;

                            int ni = i + di;
                            int nj = j + dj;

                            if (ni >= 0 && ni < _gridSize && nj >= 0 && nj < _gridSize)
                            {
                                neighbors.Add(_cells[ni, nj]);
                            }
                        }
                    }
                    _cells[i, j].SetNeighbors(neighbors);
                }
            }

            StringBuilder res = new StringBuilder();
            for (int j = 0; j < _gridSize; j++)
            {
                for (int i = 0; i < _gridSize; i++)
                {
                    if(mines[i, j])
                    {
                        res.Append("1 ");
                    } else
                    {
                        res.Append("0 ");
                    }
                }
                res.Append('\n');
            }
            UnityEngine.Debug.Log(res.ToString());
        }

        public void CellClick(int i, int j)
        {
            OnCellOpened?.Invoke(i, j, _cells[i, j].GetMinesAroundCount(), _cells[i, j].IsMine);
        }
    }
}
