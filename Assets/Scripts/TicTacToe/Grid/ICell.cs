using TicTacToe.Grid.CellStateMachine;

namespace TicTacToe.Grid
{
    public interface ICell
    {
        SelectionStateMachine Selection { get; }
        void Select();
    }
}