using UnityEngine;
using Zenject;

namespace Minesweeper
{
    public class GridPresenter : IInitializable
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
        }
    }
}
