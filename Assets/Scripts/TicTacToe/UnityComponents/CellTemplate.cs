using TicTacToe.Grid;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace TicTacToe.UnityComponents
{
    public class CellTemplate : MonoBehaviour, IPointerDownHandler
    {
        [Inject] private SelectionChecker _selectionChecker;
        private ICell _cell;

        [field: SerializeField] public Image Main; 
        
        public void Init(ICell cell)
        {
            _cell = cell;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _selectionChecker.Check(_cell, typeof(PlayerTurn));
        }
    }
}