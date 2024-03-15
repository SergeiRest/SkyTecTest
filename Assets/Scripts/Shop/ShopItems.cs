using System;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using Unity.Plastic.Newtonsoft.Json.Converters;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class ShopItems
    {
        [Inject]
        private void Construct(TextAsset jsonFile)
        {
            Container = JsonConvert.DeserializeObject<ShopItemsContainer>(jsonFile.text, new Converter());
            foreach (var i in Container.shopItems)
            {
                if (i is ValuableShopItem item)
                {
                    Debug.Log(item.amount);
                }
            }
        }
        
        public ShopItemsContainer Container { get; private set; }

        
        // private string json = "{" +
        //                       "shopItems:[{ key: \"gold\", " +
        //                       "amount: 100, price: \"1.99\", currency: \"usd\"" +
        //                       " },{ key: \"silver\", amount: 5000, price: \"0.99\", currency: \"usd\" },]}";/* +
        //                       "{ key: \"starterPack\", items: { key: \"sword\", damage: \"14\" }," +
        //                       " { key: \"ressurect\", amount: 3 } , price: \"1.99\", currency: \"usd\" },] " +
        //                       "}";*/

    }

    public class Converter : CustomCreationConverter<IShopItem>
    {
        public override IShopItem Create(Type objectType)
        {
            throw new NotImplementedException();
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jObject = JObject.Load(reader);

            var target = CreateContact(jObject);

            return target;
        }
        
        private IShopItem CreateContact(JObject jObject) {
            var contactType = (string)jObject.Property("key");
            var json = jObject.ToString();

            switch (contactType) {
                case "gold": {
                    return DeserializeObject<GoldShopItem>(json);
                }
                case "silver": {
                    return DeserializeObject<SilverShopItem>(json);
                }
                // case "starterPack": {
                //     return DeserializeObject<VkContact>(json);
                // }
                default:
                    throw new NotSupportedException("Unexpected contactType: " + contactType);
            }
        }

        private T DeserializeObject<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }

    public class ShopItemsContainer
    {
        public List<ShopItem> shopItems { get; set; }
    }
    
    public class GoldShopItem : ValuableShopItem
    {
        // public string key { get; set; }
        // public float price { get; set; }
        // public string currency { get; set; }
        // public string amount { get; set; }
        //
        // public void AddToPlayer()
        // {
        // }
    }
    
    public class SilverShopItem : ValuableShopItem
    {
        // public string key { get; set; }
        // public float price { get; set; }
        // public string currency { get; set; }
        // public string amount { get; set; }
    }

    public class PackShopItem : ShopItem
    {
        
    }

    public class ValuableShopItem : ShopItem
    {
        public int amount;
    }
    
    public abstract class ShopItem : IShopItem
    {
        public string key { get; set; }
        public float price { get; set; }
        public string currency { get; set; }
    }

    public interface IShopItem
    {
        public string key { get; set; }
        public float price { get; set; }
        public string currency { get; set; }
    }
}