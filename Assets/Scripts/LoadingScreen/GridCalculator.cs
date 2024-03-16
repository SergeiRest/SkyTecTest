using UnityEngine;
using Zenject;
using Grid = TicTacToe.Grid.Grid;

namespace LoadingScreen
{
    public class GridCalculator
    {
        [Inject] private Grid _grid;
        
        public bool IsAvailable(Pick pick)
        {
            return (CalculateHorizontal(pick) || CalculateVertical(pick) || CalculateDiagonal(pick));
        }

        private bool CalculateHorizontal(Pick pick)
        {
            for (int i = 0; i < _grid.Cells.Length / 3; i++)
            {
                bool value = true;
                for (int j = 0; j < 3; j++)
                {
                    value &= _grid.Cells[i * 3 + j].Picked == pick;
                }

                if (value)
                    return true;
            }

            return false;
        }
        
        private bool CalculateVertical(Pick pick)
        {
            for (int i = 0; i < _grid.Cells.Length / 3; i++)
            {
                bool value = true;
                for (int j = 0; j < 3; j++)
                {
                    value &= _grid.Cells[i + j * 3].Picked == pick;
                }

                if (value)
                    return true;
            }

            return false;
        }

        private bool CalculateDiagonal(Pick pick)
        {
            bool firstDiagonal = true;
            for (int i = 0; i < _grid.Cells.Length; i += _grid.Cells.Length / 3 + 1)
            {
                firstDiagonal &= _grid.Cells[i].Picked == pick;
            }

            if (firstDiagonal)
                return firstDiagonal;

            bool secondDiagonal = true;
            
            for (int i = _grid.Cells.Length / 3 - 1; i < _grid.Cells.Length - 1; i += _grid.Cells.Length / 3 - 1)
            {
                secondDiagonal &= _grid.Cells[i].Picked == pick;
            }

            return secondDiagonal;
        }
    }
}