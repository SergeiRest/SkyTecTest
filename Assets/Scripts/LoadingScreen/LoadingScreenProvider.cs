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
            CreateBasic(config);
        }

        public void LoadGameplay()
        {
            LoadingScreenConfig config = _configsContainer.GetConfig("Gameplay");
            CreateBasic(config);
        }

        private void CreateBasic(LoadingScreenConfig config)
        {
            DefaultLoadingScreenTemlate screen = _screenFactory.GetScreen<DefaultLoadingScreenTemlate>();
            var loadModel = new BaseLoadingScreenModel();
            loadModel.Init(screen, config);
            _current = loadModel;
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