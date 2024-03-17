using DefaultNamespace.DialogueWindow;
using UnityEngine;

namespace DialogueWindow.Configs
{
    [CreateAssetMenu(fileName = "DialogueConfigsContainer", menuName = "Data/DialogueConfigsContainer")]
    public class DialogueWindowsContainer : ScriptableObject
    {
        public SelectDifficultyScreenConfig DifficultyConfig;
    }
}