using TicTacToe.Grid;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TicTacToe.UnityComponents
{
    public class CellTemplate : MonoBehaviour, IPointerDownHandler
    {
        private ICell _cell;
        
        public void Init(ICell cell)
        {
            _cell = cell;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _cell.Select();
        }
    }
}