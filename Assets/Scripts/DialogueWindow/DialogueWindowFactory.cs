using System.Linq;
using UnityEngine;
using Zenject;

namespace DialogueWindow
{
    public class DialogueWindowFactory
    {
        [Inject] private DiContainer _diContainer;
        
        private string _path = "DialogueWindows";


        public void Get<T>() where T : AbstractDialogueWindow
        {
            T prefab = Resources.LoadAll<T>(_path).First();
            T model = _diContainer.InstantiatePrefabForComponent<T>(prefab);
        }
    }
}