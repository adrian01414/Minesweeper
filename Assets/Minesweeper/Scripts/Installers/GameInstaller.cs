using Minesweeper;
using UnityEngine;
using Zenject;

namespace Minesweeper
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfig _levelConfig = null;

        public override void InstallBindings()
        {
            Container.Bind<LevelConfig>()
                .FromInstance(_levelConfig)
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<GameController>()
                .FromNew()
                .AsSingle()
                .WithArguments<int, int>(_levelConfig.GridSize, _levelConfig.MinesCount)
                .NonLazy();
        }
    }
}