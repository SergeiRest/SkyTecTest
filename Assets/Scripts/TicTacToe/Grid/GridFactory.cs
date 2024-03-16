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
            Grid grid = new Grid();
            _diContainer.BindInterfacesAndSelfTo<Grid>().FromInstance(grid).AsSingle();

            List<ICell> cells = new List<ICell>();
            GridTemplate gridTemplate = Object.Instantiate(_gridConfig.GridTemplate);

            
            for (int i = 0; i < grid.CellsCount; i++)
            {
                CellTemplate monoCell = _diContainer.InstantiatePrefabForComponent<CellTemplate>(_gridConfig.CellTemplate, gridTemplate.CellParent);
                ICell cell = new BasicCell(monoCell.Main);
                monoCell.Init(cell);
                cells.Add(cell);
            }
            
            grid.SetCells(cells.ToArray());
        }
    }
}