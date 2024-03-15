using UnityEngine;

namespace Shop.View
{
    public class BaseItemView : ShopItemView
    {
        [SerializeField] private ItemPreset _itemPreset;

        public void Init(Sprite item, string description)
        {
            _itemPreset.UpdateView(item, description);
        }
    }
}