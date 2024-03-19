using DialogueWindow;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pause
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _pause;

        [Inject]
        private void Construct(PauseHandler pauseHandler)
        {
            _pause.onClick.AddListener(pauseHandler.Pause);
        }
    }
}