using LoadingScreen.Installer;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainMenu
{
    public class EnterGameplayButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [Inject]
        private void Construct(LoadingScreenProvider provider)
        {
            _button.onClick.AddListener(provider.LoadGameplay);
        }
    }
}