using UnityEngine;
using Zenject;

namespace Minesweeper
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private GridView _gridView = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GridPresenter>()
                    .FromNew()
                    .AsSingle()
                    .WithArguments(_gridView)
                    .NonLazy();
        }
    }
}
