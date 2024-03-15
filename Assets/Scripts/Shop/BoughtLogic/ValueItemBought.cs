using UnityEngine;

namespace Shop.BoughtLogic
{
    public class ValueItemBought
    {
        public void Buy(ValuableShopItem item)
        {
            Debug.Log($"Купили и получили {item.amount} {item.key}");
        }
    }
}