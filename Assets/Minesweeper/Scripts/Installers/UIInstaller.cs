using Minesweeper;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private GridView _gridView = null;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GridPresenter>()
                .AsCached()
                .WithArguments(_gridView)
                .NonLazy();
    }
}