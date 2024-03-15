using System;
using System.Collections.Generic;

namespace TicTacToe.Grid.CellStateMachine
{
    public class SelectionStateMachine : IStateSwitcher
    {
        private Dictionary<Type, CellSelectionState> _states = new Dictionary<Type, CellSelectionState>();
        private CellSelectionState currentState;
        
        public SelectionStateMachine()
        {
            ActiveState activeState = new ActiveState(this);
            InactiveState inactiveState = new InactiveState(this);
            _states.Add(activeState.GetType(), activeState);
            _states.Add(inactiveState.GetType(), inactiveState);
            currentState = activeState;
        }
        
        public void SwitchState<T>() where T : CellSelectionState
        {
            Type type = typeof(T);
            if (_states.TryGetValue(type, out var newState))
            {
                currentState = newState;
            }
        }

        public void Select()
        {
            currentState.Select();
        }
    }
}