using DialogueWindow.Configs;
using LoadingScreen.Installer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DialogueWindow
{
    public class TestWindow : AbstractDialogueWindow
    {
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Button _interaction;

        private SelectDifficultyScreenConfig _config;

        [Inject]
        private void Construct(DialogueWindowsContainer container, LoadingScreenProvider provider)
        {
            _config = container.DifficultyConfig;
            _description.text = _config.Description;
            _interaction.onClick.AddListener(() =>
            {
                provider.LoadGameplay();
                Destroy(gameObject);
            });
        }
    }
}