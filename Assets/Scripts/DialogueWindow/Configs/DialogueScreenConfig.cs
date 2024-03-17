using UnityEngine;

namespace DialogueWindow.Configs
{
    [CreateAssetMenu(fileName = "DefaultScreenConfig", menuName = "Data/DefaultScreenConfig")]
    public class DialogueScreenConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite Main { get; private set; }
    }
}