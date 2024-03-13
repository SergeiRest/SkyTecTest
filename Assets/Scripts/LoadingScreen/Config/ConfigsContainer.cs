using UnityEngine;

namespace LoadingScreen.Config
{
    public class ConfigsContainer
    {
        private string _path;

        public ConfigsContainer(string path)
        {
            _path = path;
        }

        public LoadingScreenConfig GetConfig(string name)
        {
            return Resources.Load<LoadingScreenConfig>(_path + $"/{name}");
        }
    }
}