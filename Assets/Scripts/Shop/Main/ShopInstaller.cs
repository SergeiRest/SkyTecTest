using UnityEngine;
using Zenject;

namespace Shop
{
    public class ShopInstaller : MonoInstaller
    {
        [SerializeField] private ShopTemplate _shop;
        [SerializeField] private TextAsset _data;
        [SerializeField] private ShopViewData _viewData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Main.ShopHandler>().FromNew().AsSingle().WithArguments(_shop).NonLazy();
            Container.BindInterfacesAndSelfTo<ShopItems>().FromNew().AsSingle().WithArguments(_data).NonLazy();
            Container.BindInterfacesAndSelfTo<ShopItemFactory>().FromNew().AsSingle().WithArguments(_viewData).NonLazy();
        }
    }
}