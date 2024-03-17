using System;
using DefaultNamespace.SaveSystem;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Player
{
    public class Player : IDisposable
    {
        private PlayerScore score;

        public PlayerScore Score => score;

        [Inject]
        private void Construct(SaveService saveService)
        {
            score = saveService.Load<PlayerScore>("playerScore");
        }

        public void Dispose()
        {
            Score.UpdateView = null;
        }
    }
}