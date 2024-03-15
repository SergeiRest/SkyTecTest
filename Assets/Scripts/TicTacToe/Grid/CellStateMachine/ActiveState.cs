using UnityEngine;

namespace TicTacToe.Grid.CellStateMachine
{
    public class ActiveState : CellSelectionState
    {
        public ActiveState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Select()
        {
            _stateSwitcher.SwitchState<InactiveState>();
            Debug.Log("Select");
        }
    }
}