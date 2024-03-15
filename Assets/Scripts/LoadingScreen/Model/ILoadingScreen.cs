using System;
using LoadingScreen.Config;

namespace LoadingScreen.Model
{
    public interface ILoadingScreen
    {
        public event Action OnLoadingFinished;
        public void Dispose();

    }
}