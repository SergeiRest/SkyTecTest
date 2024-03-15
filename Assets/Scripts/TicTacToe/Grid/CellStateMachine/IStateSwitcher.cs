namespace TicTacToe.Grid.CellStateMachine
{
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T : CellSelectionState;
    }
}