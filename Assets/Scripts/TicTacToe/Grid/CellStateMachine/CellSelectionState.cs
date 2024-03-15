namespace TicTacToe.Grid.CellStateMachine
{
    public abstract class CellSelectionState
    {
        protected IStateSwitcher _stateSwitcher;
        
        public CellSelectionState(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }
        
        public abstract void Select();
    }
}