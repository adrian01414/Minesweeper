using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private LevelConfig _levelConfig = null;

    public override void InstallBindings()
    {
        Container.Bind<LevelConfig>()
            .FromInstance(_levelConfig)
            .AsSingle()
            .NonLazy();
    }
}