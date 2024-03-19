using DefaultNamespace.Player;
using LoadingScreen.Installer;
using TicTacToe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DialogueWindow
{
    public class FinishGameWindow : AbstractDialogueWindow
    {
        [SerializeField] private Button _continue;
        [SerializeField] private TextMeshProUGUI _score;

        protected ScoreAnimation _scoreAnimation;

        [Inject]
        public virtual void Construct(GameInitializer gameInitializer, LoadingScreenProvider loadingProvider, Player player)
        {
            _scoreAnimation = new ScoreAnimation();
            
            _continue.onClick.AddListener(() =>
            {
                loadingProvider.LoadMainMenu();
                gameInitializer.Dispose();
                Destroy(gameObject);
            });
            
            _continue.gameObject.SetActive(false);
        }

        protected void UpdateScore(int value) 
            => _score.text = $"Score :{value}";

        protected void ShowButton() 
            => _continue.gameObject.SetActive(true);
    }
}