using System;
using UnityEngine;

namespace TicTacToe
{
    public interface ITurn
    {
        public Pick Pick { get; }
        public Sprite Active { get; }
        void Activate();
    }
}