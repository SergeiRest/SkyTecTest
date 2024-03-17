using Zenject;

namespace DefaultNamespace.SaveSystem
{
    public class SaveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveService>().FromNew().AsSingle().NonLazy();
        }
    }
}