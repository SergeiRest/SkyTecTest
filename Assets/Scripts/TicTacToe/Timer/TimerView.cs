using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace TicTacToe.Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        
        private RoundTimer _timer;

        [Inject]
        private void Construct(RoundTimer timer)
        {
            _timer = timer;
            _timer.Update += UpdateView;
        }

        private void UpdateView(float value)
        {
            _timerText.text = value.ToString("0");
        }

        private void OnDestroy()
        {
            _timer.Update -= UpdateView;
        }
    }
}