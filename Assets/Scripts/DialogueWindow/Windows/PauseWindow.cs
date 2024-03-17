using Pause;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.DialogueWindow
{
    public class PauseWindow : AbstractDialogueWindow
    {
        [SerializeField] private Button _continue;

        [Inject]
        private void Construct(PauseHandler pauseHandler)
        {
            _continue.onClick.AddListener(() =>
            {
                pauseHandler.Unpause();
                Destroy(gameObject);
            });
        }
    }
}