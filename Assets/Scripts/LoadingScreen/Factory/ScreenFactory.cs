using System.Linq;
using UnityEngine;

namespace LoadingScreen.Factory
{
    public class ScreenFactory : IScreenFactory
    {
        private string _path = "LoadingScreenTemplates";
        public T GetScreen<T>() where T : LoadingScreenTemplate
        {
            T prefab = Resources.LoadAll<T>(_path).First();
            T screen = Object.Instantiate(prefab);
            screen.transform.localPosition = Vector3.zero;

            return (T)screen;
        }
    }
}