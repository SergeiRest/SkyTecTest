using System;
using LoadingScreen.Config;

namespace LoadingScreen.Model
{
    public interface ILoadingScreen
    {
        public event Action OnLoadingFinished;
        public void Dispose();

    }

    public interface IDefaultLoadingScreen : ILoadingScreen
    {
        public void Init(DefaultLoadingScreenTemlate template, LoadingScreenConfig config);
    }
}