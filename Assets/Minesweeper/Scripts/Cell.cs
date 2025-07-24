using UnityEngine;

namespace Minesweeper {

    public class Cell
    {
        public bool IsOpened { get; private set; } = false;
        public bool IsMine { get; private set; } = false;

        private int _neighborsCount = 0;
        public int NeighborsCount
        {
            get => _neighborsCount;
            set
            {
                if(value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("NeighborsCount can not be less than zero");
                } else if (value > 9)
                {
                    throw new System.ArgumentOutOfRangeException("NeighborsCount can not be more than nine");
                }
            }
        }

        public Cell(bool isMine)
        {
            IsMine = isMine;
        }
    }
}


