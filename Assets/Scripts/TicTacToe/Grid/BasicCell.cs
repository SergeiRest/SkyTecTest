using TicTacToe.Grid.CellStateMachine;

namespace TicTacToe.Grid
{
    public class BasicCell : ICell
    {
        public SelectionStateMachine Selection { get; } 
            = new SelectionStateMachine();

        public void Select()
        {
            Selection.Select();
        }
    }
}