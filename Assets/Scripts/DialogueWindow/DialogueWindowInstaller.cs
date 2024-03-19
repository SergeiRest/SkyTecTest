using DialogueWindow.Configs;
using UnityEngine;
using Zenject;

namespace DialogueWindow
{
    public class DialogueWindowInstaller : MonoInstaller
    {
        [SerializeField] private DialogueWindowsContainer _windowsContainer;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DialogueWindowPresenter>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DialogueWindowsContainer>().FromInstance(_windowsContainer).AsSingle()
                .NonLazy();
        }
    }
}