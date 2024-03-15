using System.Collections.Generic;
using TicTacToe.UnityComponents;
using UnityEngine;
using Zenject;

namespace TicTacToe.Grid
{
    public class GridFactory : IGridFactory
    {
        [Inject] private GridConfig _gridConfig;
        [Inject] private DiContainer _diContainer;
        
        public void Create()
        {
            List<ICell> cells = new List<ICell>();
            Grid grid = new Grid();
            GridTemplate gridTemplate = Object.Instantiate(_gridConfig.GridTemplate);

            _diContainer.BindInterfacesAndSelfTo<Grid>().FromInstance(grid).AsSingle().NonLazy();
            
            for (int i = 0; i < grid.CellsCount; i++)
            {
                ICell cell = new BasicCell();
                CellTemplate monoCell = Object.Instantiate(_gridConfig.CellTemplate, gridTemplate.CellParent, true);
                monoCell.Init(cell);
                cells.Add(cell);
            }
            
            grid.SetCells(cells.ToArray());
        }
    }
}