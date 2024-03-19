using Zenject;

namespace PlayerInput
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputHandler>().FromNew().AsSingle();
        }
    }
}