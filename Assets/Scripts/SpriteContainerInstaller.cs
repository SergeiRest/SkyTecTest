using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class SpriteContainerInstaller : MonoInstaller
    {
        [SerializeField] private SpriteData _spriteData;

        public override void InstallBindings()
        {
            Container.Bind<SpriteData>().FromInstance(_spriteData).AsSingle().NonLazy();
        }
    }
}