using TicTacToe.UnityComponents;
using UnityEngine;

namespace TicTacToe.Grid
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "Data/GridConfig")]
    public class GridConfig : ScriptableObject
    {
        public GridTemplate GridTemplate;
        public CellTemplate CellTemplate;
    }
}