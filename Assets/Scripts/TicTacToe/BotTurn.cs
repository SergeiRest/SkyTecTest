using System.Linq;
using TicTacToe.Grid;
using UnityEngine;
using Zenject;

namespace TicTacToe
{
    public class BotTurn : ITurn
    {
        [Inject] private Grid.Grid _grid;
        [Inject] private SelectionChecker _checker;

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