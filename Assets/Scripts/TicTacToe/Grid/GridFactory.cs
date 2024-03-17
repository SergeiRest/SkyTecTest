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

        private Grid _grid;
        
        public void Create()
        {
            _grid = new Grid();
            if (!_diContainer.HasBinding<Grid>())
            {
                _diContainer.BindInterfacesAndSelfTo<Grid>().FromInstance(_grid).AsSingle();
            }
            else
            {
                _diContainer.Rebind<Grid>().FromInstance(_grid);
            }

            List<ICell> cells = new List<ICell>();
            GridTemplate gridTemplate = Object.Instantiate(_gridConfig.GridTemplate);

            
            for (int i = 0; i < _grid.CellsCount; i++)
            {
                CellTemplate monoCell = _diContainer.InstantiatePrefabForComponent<CellTemplate>(_gridConfig.CellTemplate, gridTemplate.CellParent);
                ICell cell = new BasicCell(monoCell.Main);
                monoCell.Init(cell);
                cells.Add(cell);
            }
            
            _grid.Init(gridTemplate, cells.ToArray());
            cells.Clear();
        }

        public void Clear()
        {
            _grid.Dispose();
        }
    }
}