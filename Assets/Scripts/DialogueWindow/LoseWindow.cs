using LoadingScreen.Installer;
using TicTacToe;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.DialogueWindow
{
    public class LoseWindow : AbstractDialogueWindow
    {
        [SerializeField] private Button _continue;
        
        [Inject]
        private void Construct(GameInitializer gameInitializer, LoadingScreenProvider loadingProvider)
        {
            _continue.onClick.AddListener(() =>
            {
                loadingProvider.LoadMainMenu();
                gameInitializer.Dispose();
                Destroy(gameObject);
            });
        }
    }
}