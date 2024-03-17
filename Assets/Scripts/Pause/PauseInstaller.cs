﻿using Zenject;

namespace Pause
{
    public class PauseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PauseHandler>().FromNew().AsSingle().NonLazy();
        }
    }
}