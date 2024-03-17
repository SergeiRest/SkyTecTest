using Zenject;

namespace DefaultNamespace.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Player>().FromNew().AsSingle().NonLazy();
        }
    }
}