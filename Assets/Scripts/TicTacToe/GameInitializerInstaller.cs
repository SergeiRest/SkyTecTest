using TicTacToe.Grid;
using UnityEngine;
using Zenject;

namespace TicTacToe
{
    public class GameInitializerInstaller : MonoInstaller
    {
        [SerializeField] private GridConfig _gridConfig;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GridConfig>().FromInstance(_gridConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<GameInitializer>().FromNew().AsSingle().NonLazy();
        }
    }
}