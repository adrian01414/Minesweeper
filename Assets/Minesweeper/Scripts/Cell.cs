using System.Collections.Generic;

namespace Minesweeper {

    public class Cell
    {
        public readonly int MinesAroundCount;

        public bool IsOpened { get; private set; } = false;
        public bool IsMine { get; private set; } = false;

        private List<Cell> _neighbors = null;

        public Cell(bool isMine, int minesAroundCount)
        {
            IsMine = isMine;
            if (minesAroundCount < 0)
            {
                throw new System.ArgumentOutOfRangeException("MinesAroundCount can not be less than zero");
            }
            else if (minesAroundCount > 9)
            {
                throw new System.ArgumentOutOfRangeException("MinesAroundCount can not be more than nine");
            }
            MinesAroundCount = minesAroundCount;
        }
    }
}


