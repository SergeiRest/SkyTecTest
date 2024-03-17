using DefaultNamespace.SaveSystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Player
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;

        [Inject]
        private void Construct(Player player)
        {
            _score.text = player.Score.Score.ToString();
            player.Score.UpdateView += UpdateScore;
        }

        private void UpdateScore(int score)
        {
            _score.text = score.ToString();
        }
    }
}