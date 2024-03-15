using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "SpriteData", menuName = "Data/Sprites")]
    public class SpriteData : ScriptableObject
    {
        [SerializeField] private Item[] Items;

        public Sprite GetSprite(string key)
            => Items.First(k => k.Key == key).Sprite;
    }

    [Serializable]
    public struct Item
    {
        public string Key;
        public Sprite Sprite;
    }
}