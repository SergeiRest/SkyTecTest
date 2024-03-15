using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.View
{
    public class ItemPreset : MonoBehaviour
    {
        [SerializeField] private Image _main;
        [SerializeField] private TextMeshProUGUI _description;

        public void UpdateView(Sprite main, string description)
        {
            _main.sprite = main;
            _description.text = description;
        }
    }
}