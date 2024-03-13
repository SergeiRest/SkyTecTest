using UnityEngine;
using System;

namespace LoadingScreen.Config
{
    [CreateAssetMenu(fileName = "ScreenConfig", menuName = "Data/LoadingScreenConfig")]
    public class LoadingScreenConfig : ScriptableObject
    {
        public Sprite Main;
        
        [field: SerializeField] public LoadingInformation[] LoadingInformation { get; private set; }
    }

    [Serializable]
    public struct LoadingInformation
    {
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public float Time { get; private set; }
    }
}