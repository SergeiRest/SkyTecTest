using Shop.Main;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop
{
    public class ShopTemplate : MonoBehaviour
    {
        [SerializeField] private Button _close;
        
        [field: SerializeField] public Transform Container;

        [Inject]
        private void Construct(ShopHandler handler)
        {
            _close.onClick.AddListener(handler.Close);
        }
    }
}