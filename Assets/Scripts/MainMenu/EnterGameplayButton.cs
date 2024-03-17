using DefaultNamespace.DialogueWindow;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainMenu
{
    public class EnterGameplayButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [Inject]
        private void Construct(DialogueWindowPresenter windowPresenter)
        {
            _button.onClick.AddListener(windowPresenter.Show<TestWindow>);
        }
    }
}