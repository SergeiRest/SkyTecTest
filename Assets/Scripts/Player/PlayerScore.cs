using System;
using DefaultNamespace.SaveSystem;
using UnityEngine;

namespace DefaultNamespace.Player
{
    [Serializable]
    public class PlayerScore : ISaveLoad
    {
        private string key = "playerScore";

        public int Score;
        
        
        public string Key => key;
        public event Action<ISaveLoad, string> Update;
        public Action<int> UpdateView;

        public void Increase(int value)
        {
            Score += value;
            SendEvents();
        }

        public void Decrease(int value)
        {
            Score -= value;
            Score = Mathf.Clamp(Score, 0, int.MaxValue);
            SendEvents();
        }

        private void SendEvents()
        {
            Update?.Invoke(this, key);
            UpdateView?.Invoke(Score);
        }
    }
}