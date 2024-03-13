using LoadingScreen.Config;
using LoadingScreen.Factory;
using LoadingScreen.Model;
using UnityEngine;

namespace LoadingScreen.Installer
{
    public class LoadingScreenProvider
    {
        private IScreenFactory _screenFactory;
        private ConfigsContainer _configsContainer;
        private ILoadingScreen _current;
        
        public LoadingScreenProvider()
        {
            _screenFactory = new ScreenFactory();
            _configsContainer = new ConfigsContainer("LoadingConfigs");
        }

        public void LoadMainMenu()
        {
            LoadingScreenConfig config = _configsContainer.GetConfig("MainMenu");
            LoadingScreenTemplate screen = _screenFactory.GetScreen<LoadingScreenTemplate>();
            _current = new BaseLoadingScreen();
            _current.Init(screen, config);
            _current.OnLoadingFinished += Dispose;
        }

        private void Dispose()
        {
            _current.OnLoadingFinished -= Dispose;
            _current.Dispose();
            _current = null;
        }
    }
}