using LoadingScreen.Config;
using LoadingScreen.Factory;
using LoadingScreen.Model;
using TicTacToe;
using UnityEngine;
using Zenject;

namespace LoadingScreen.Installer
{
    public class LoadingScreenProvider
    {
        [Inject] private GameInitializer _gameInitializer;
        [Inject] private DiContainer _diContainer;
        
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
            CreateBasic<GameplayToMenuModel>(config);
        }

        public void LoadGameplay()
        {
            LoadingScreenConfig config = _configsContainer.GetConfig("Gameplay");
            _gameInitializer.Initialize();
            CreateBasic<MenuToGameplayModel>(config);
        }

        private void CreateBasic<T>(LoadingScreenConfig config) where T : BaseLoadingScreenModel, new()
        {
            DefaultLoadingScreenTemplate screen = _screenFactory.GetScreen<DefaultLoadingScreenTemplate>();
            var loadModel = new T();
            _diContainer.Inject(loadModel);
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