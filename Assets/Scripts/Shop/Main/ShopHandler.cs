using UnityEngine;
using Zenject;

namespace Shop.Main
{
    public class ShopHandler
    {
        [Inject] private DiContainer _diContainer;
        
        private ShopTemplate _prefab;
        private ShopTemplate _opened;
        private Shop _shop;

        public ShopHandler(ShopTemplate template)
        {
            _prefab = template;
        }
        
        public void Open()
        {
            if(_opened != null)
                Object.Destroy(_opened.gameObject);
            
            _opened = _diContainer.InstantiatePrefabForComponent<ShopTemplate>(_prefab);

            _shop = new Shop();
            _shop.Main = _opened;
            _diContainer.Inject(_shop);
            _shop.Open();
        }

        public void Close()
        {
            _shop.Dispose();
            _shop = null;
            Object.Destroy(_opened.gameObject);
        }
    }
}