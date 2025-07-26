using System.Collections.Generic;

namespace Minesweeper {

    public class Cell
    {
        public bool IsMine { get; private set; } = false;

        private List<Cell> _neighbors = null;
        public IReadOnlyList<Cell> Neighbors { get => _neighbors; }

        public Cell(bool isMine)
        {
            IsMine = isMine;
        }

        public void SetNeighbors(List<Cell> neighbors)
        {
            if (neighbors.Count < 0)
            {
                throw new System.ArgumentOutOfRangeException("Neighbors Count can not be less than zero");
            }
            else if (neighbors.Count > 9)
            {
                throw new System.ArgumentOutOfRangeException("Neighbors Count can not be more than nine");
            }
            _neighbors = new List<Cell>(neighbors);
        }

        public int GetMinesAroundCount()
        {
            int mineCount = 0;
            foreach(var neighbor in _neighbors)
            {
                if (neighbor.IsMine) mineCount++;
            }
            return mineCount;
        }
    }
}


