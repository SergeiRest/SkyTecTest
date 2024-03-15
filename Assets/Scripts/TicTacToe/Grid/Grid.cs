using System;
using System.Collections.Generic;
using TicTacToe.UnityComponents;
using Object = UnityEngine.Object;

namespace TicTacToe.Grid
{
    public class Grid : IDisposable
    {
        private IEnumerable<ICell> _cells;
        private GridTemplate _view;

        public int CellsCount { get; private set; } = 9;

        public void SetCells(ICell[] cells)
        {
            _cells = cells;
        }
        
        public void Dispose()
        {
            _cells = null;
            Object.Destroy(_view.gameObject);
        }
    }
}