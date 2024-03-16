using System;using TicTacToe.Grid.CellStateMachine;
using UnityEngine;

public enum Pick
{
    None,
    Player,
    Bot,
}
namespace TicTacToe.Grid
{
    public interface ICell
    {
        public Pick Picked { get; }
        SelectionStateMachine Selection { get; }
        void Select(Pick by);

        void UpdateView(Sprite sprite);

        bool IsActive();
    }
}