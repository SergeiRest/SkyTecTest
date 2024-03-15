using System.Collections.Generic;
using DefaultNamespace;
using Shop.BoughtLogic;
using Shop.View;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class ShopItemFactory
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private ShopItems _shopItems;
        [Inject] private SpriteData _spriteData;
        private ShopViewData _data;

        private ShopItemFactory(ShopViewData data)
        {
            _data = data;
        }

        public List<ShopItemView> GetItems<T>(Transform parent) where T : ShopItemView
        {
            List<ShopItemView> _views = new List<ShopItemView>();

            T view = null;
            
            foreach (var item in _shopItems.Container.shopItems)
            {
                if (item is ValuableShopItem current)
                {
                    BaseItemView baseItemView = view as BaseItemView;
                    baseItemView = _diContainer.InstantiatePrefabForComponent<BaseItemView>(_data.BaseItemView);
                    baseItemView.transform.SetParent(parent);
                    baseItemView.Init(_spriteData.GetSprite(current.key), current.amount.ToString());
                    baseItemView.InitializeBuying(() => new ValueItemBought().Buy(current));
                    _views.Add(baseItemView);
                }
            }

            return _views;
        }
    }
}