using TicTacToe.Grid.CellStateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Grid
{
    public class BasicCell : ICell
    {
        private Image _main;
        private Pick _picked;

        public Pick Picked => _picked;

        public SelectionStateMachine Selection { get; } 
            = new SelectionStateMachine();

        public BasicCell(Image position)
        {
            _picked = Pick.None;
            _main = position;
        }
        
        public void Select(Pick by)
        {
            _picked = by;
            Selection.Select();
        }

        public void UpdateView(Sprite sprite)
        {
            _main.sprite = sprite;
        }

        public bool IsActive() 
            => Selection.IsActive();
    }
}