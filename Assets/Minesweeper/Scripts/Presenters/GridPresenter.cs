using System;
using UnityEngine;
using Zenject;

namespace Minesweeper
{
    public class GridPresenter : IInitializable, IDisposable
    {
        private GridView _gridView = null;
        private GameController _gameController = null;

        public GridPresenter(GridView gridView, GameController gameController)
        {
            _gridView = gridView;
            _gameController = gameController;
        }

        public void Initialize()
        {
            _gridView.DrawGrid();
            _gridView.OnCellClick += CellClick;
            _gameController.OnCellOpened += CellOpen;
        }

        private void CellOpen(int i, int j, int minesAroundCount, bool isMine)
        {
            _gridView.OpenCell(i, j, minesAroundCount, isMine);
        }

        private void CellClick(int i, int j)
        {
            _gameController.CellClick(i, j);
        }

        public void Dispose()
        {
            _gridView.OnCellClick -= CellClick;
        }
    }
}
