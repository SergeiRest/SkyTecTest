using Zenject;

namespace TicTacToe.Timer
{
    public class TimerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RoundTimer>().FromNew().AsSingle().NonLazy();
        }
    }
}