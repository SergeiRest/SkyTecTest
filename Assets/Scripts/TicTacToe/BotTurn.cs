using System.Linq;
using TicTacToe.Grid;
using UnityEngine;
using Zenject;

namespace TicTacToe
{
    public class BotTurn : ITurn
    {
        private Grid.Grid _grid;
        private SelectionChecker _checker;

        [Inject]
        private void Construct(Grid.Grid grid, SelectionChecker checker)
        {
            _grid = null;
            _checker = null;

            _grid = grid;
            _checker = checker;
        }

        private Pick _pick = Pick.Bot;
        
        public BotTurn(Sprite sprite)
        {
            Active = sprite;
        }

        public Pick Pick => _pick;
        public Sprite Active { get; }

        public void Activate()
        {
            var cells = _grid.GetActiveCells();

            int random = Random.Range(0, cells.Count());
            ICell cell = cells[random];
            _checker.Check(cell, this.GetType());
        }
    }
}