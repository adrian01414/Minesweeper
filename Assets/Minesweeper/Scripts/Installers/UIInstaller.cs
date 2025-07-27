using UnityEngine;
using Zenject;

namespace Minesweeper
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private GridView _gridView = null;
        [SerializeField] private Sprites _sprites = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GridPresenter>()
                    .FromNew()
                    .AsSingle()
                    .WithArguments(_gridView)
                    .NonLazy();

            Container.Bind<Sprites>()
                .FromInstance(_sprites)
                .AsSingle()
                .NonLazy();
        }
    }
}
