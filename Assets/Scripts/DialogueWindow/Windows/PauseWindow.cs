using LoadingScreen.Installer;
using Pause;
using TicTacToe;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DialogueWindow
{
    public class PauseWindow : AbstractDialogueWindow
    {
        [SerializeField] private Button _continue;
        [SerializeField] private Button _exit;

        [Inject]
        private void Construct(PauseHandler pauseHandler, LoadingScreenProvider loadingProvider, GameInitializer initializer)
        {
            _continue.onClick.AddListener(() =>
            {
                pauseHandler.Unpause();
                Destroy(gameObject);
            });
            
            _exit.onClick.AddListener(() =>
            {
                pauseHandler.Unpause();
                initializer.Dispose();
                loadingProvider.LoadMainMenu();
                Destroy(gameObject);
            });
        }
    }
}