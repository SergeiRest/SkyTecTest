using System;
using UnityEngine;
using Zenject;

namespace TicTacToe.Timer
{
    public class RoundTimer : ITickable
    {
        private bool _isActive = false;
        private float _timerTick;

        public event Action<float> Update;

        public void Start()
        {
            _timerTick = 0;
            _isActive = true;
        }

        public void Stop() 
            => _isActive = false;

        public void Tick()
        {
            if(!_isActive)
                return;
            
            _timerTick += Time.deltaTime;
            Update?.Invoke(_timerTick);
        }
    }
}