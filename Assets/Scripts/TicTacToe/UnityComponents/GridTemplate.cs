using UnityEngine;

namespace TicTacToe.UnityComponents
{
    public class GridTemplate : MonoBehaviour
    {
        [field: SerializeField] public Transform CellParent { get; private set; }
    }
}