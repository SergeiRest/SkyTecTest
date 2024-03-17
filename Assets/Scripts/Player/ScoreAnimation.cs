using System;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class ScoreAnimation
    {
        private float time = 1.5f;

        public void Animate(int from, int to, Action<int> OnUpdate, Action OnComplete)
        {
            DOVirtual.Int(from, to, time, (int value) =>
            {
                OnUpdate?.Invoke(value);
            })
                .OnComplete(() => OnComplete?.Invoke());
        }
    }
}