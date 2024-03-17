using DefaultNamespace.Player;
using LoadingScreen.Installer;
using TicTacToe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.DialogueWindow
{
    public class WinWindow :  AbstractDialogueWindow
    {
        [SerializeField] private Button _continue;
        [SerializeField] private TextMeshProUGUI _score;

        private ScoreAnimation _scoreAnimation;

        [Inject]
        private void Construct(GameInitializer gameInitializer, LoadingScreenProvider loadingProvider, Player.Player player)
        {
            _scoreAnimation = new ScoreAnimation();
            
            _continue.onClick.AddListener(() =>
            {
                loadingProvider.LoadMainMenu();
                gameInitializer.Dispose();
                Destroy(gameObject);
            });
            
            _continue.gameObject.SetActive(false);
            
            _scoreAnimation.Animate(player.Score.Score, player.Score.Score + 100, UpdateScore, ShowButton);
            player.Score.Increase(100);
        }

        private void UpdateScore(int value) 
            => _score.text = $"Score :{value}";

        private void ShowButton() 
            => _continue.gameObject.SetActive(true);
    }
}