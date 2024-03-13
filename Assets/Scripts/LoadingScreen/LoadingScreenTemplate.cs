using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LoadingScreen
{
    public class LoadingScreenTemplate : MonoBehaviour, IScreenTemplate
    {
        [SerializeField] private Image _fillLoading;
        [SerializeField] private Image _main;
        [SerializeField] private TextMeshProUGUI _description;

        public void Construct(Sprite loadSprite)
        {
            _main.sprite = loadSprite;
        }

        public void UpdateProgress(float value)
        {
            _fillLoading.fillAmount = value;
        }

        public void UpdateDescription(string value)
        {
            _description.text = value;
        }
    }
}