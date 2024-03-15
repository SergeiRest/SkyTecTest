using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainMenu
{
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [Inject]
        private void Construct(Shop.Main.ShopHandler shopHandler)
        {
            _button.onClick.AddListener(shopHandler.Open);
        }
    }
}