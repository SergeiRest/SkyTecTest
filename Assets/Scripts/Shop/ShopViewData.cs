using Shop.View;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopViewData", menuName = "Data/ShopViewData")]
    public class ShopViewData : ScriptableObject
    {
        [field: SerializeField] public BaseItemView BaseItemView { get; private set; }
    }
}