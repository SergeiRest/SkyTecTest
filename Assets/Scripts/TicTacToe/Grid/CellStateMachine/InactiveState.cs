using UnityEngine;

namespace TicTacToe.Grid.CellStateMachine
{
    public class InactiveState : CellSelectionState
    {
        public InactiveState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Select()
        {
        }
    }
}