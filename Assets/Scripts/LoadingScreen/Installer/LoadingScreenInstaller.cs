using Zenject;

namespace LoadingScreen.Installer
{
    public class LoadingScreenInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LoadingScreenProvider>().AsSingle().NonLazy();
        }
    }
}