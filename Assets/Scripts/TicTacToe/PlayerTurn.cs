using System;
using UnityEngine;

namespace TicTacToe
{
    public class PlayerTurn : ITurn
    {
        private Pick _pick = Pick.Player;
        
        public Pick Pick => _pick;

        public PlayerTurn(Sprite sprite)
        {
            Active = sprite;
        }
        
        public Sprite Active { get; }

        public void Activate()
        {
            
        }
    }
}