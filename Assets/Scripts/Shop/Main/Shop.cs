using System;
using Shop.View;
using Zenject;

namespace Shop.Main
{
    public class Shop : IDisposable
    {
        [Inject] private ShopItemFactory _factory;

        public ShopTemplate Main;
        
        public void Open()
        {
            _factory.GetItems<ShopItemView>(Main.Container);
        }
        
        
        public void Dispose()
        {
        }
    }
}