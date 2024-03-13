using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LoadingScreen
{
    public interface IScreenTemplate
    {
        public void UpdateProgress(float value);
    }
}