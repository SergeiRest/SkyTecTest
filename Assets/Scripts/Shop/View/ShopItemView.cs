using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.View
{
    public abstract class ShopItemView : MonoBehaviour
    {
        [field: SerializeField] private Button _buyButton;

        public void InitializeBuying(Action callback) 
            => _buyButton.onClick.AddListener(() => callback?.Invoke());
    }
}