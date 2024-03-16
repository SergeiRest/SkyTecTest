using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.UnityComponents;
using Object = UnityEngine.Object;

namespace TicTacToe.Grid
{
    public class Grid : IDisposable
    {
        private ICell[] _cells;
        private GridTemplate _view;

        public ICell[] Cells => _cells;

        public int CellsCount { get; private set; } = 9;

        public void SetCells(ICell[] cells)
        {
            _cells = cells;
        }

        public ICell[] GetActiveCells()
            => _cells.Where(state => state.IsActive()).ToArray();
        
        public void Dispose()
        {
            _cells = null;
            Object.Destroy(_view.gameObject);
        }
    }
}