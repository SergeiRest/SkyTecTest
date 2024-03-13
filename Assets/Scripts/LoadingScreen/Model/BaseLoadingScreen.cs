using System;
using DG.Tweening;
using LoadingScreen.Config;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LoadingScreen.Model
{
    public class BaseLoadingScreen : ILoadingScreen
    {
        private LoadingScreenTemplate _screen;
        private LoadingInformation[] _information;

        private int _step = 0;
        private float progress = 0;
        
        public event Action OnLoadingFinished;

        public void Init(LoadingScreenTemplate template, LoadingScreenConfig config)
        {
            _screen = template;
            _information = config.LoadingInformation;
            
            _screen.Construct(config.Main);
            StartLoading();
        }

        public void Dispose()
        {
            OnLoadingFinished = null;
            Object.Destroy(_screen.gameObject);
        }

        private void StartLoading()
        {
            _screen.UpdateDescription(_information[_step].Description);
            float endValue = (_step + 1) / (float) _information.Length;
            DOVirtual.Float(progress, endValue, _information[_step].Time,
                (float value) =>
                {
                    progress = value;
                    _screen.UpdateProgress(progress);
                }).OnComplete
                (
                    () =>
                    {
                        _step++;
                        if(_step < _information.Length)
                            StartLoading();
                        else
                            OnLoadingFinished?.Invoke();
                    }
                );
        }
    }
}