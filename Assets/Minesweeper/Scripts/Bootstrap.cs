using UnityEngine;
using Zenject;

namespace Minesweeper
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GridView _gridView;

        private LevelConfig _levelConfig;

        private void Awake()
        {
            _gridView.DrawGrid();

            // click on mines(i, j)

            bool[,] mines = MineGenerator.Generate(_levelConfig.GridSize, _levelConfig.MinesCount);
        }

        [Inject]
        private void Initialize(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }
    }
}