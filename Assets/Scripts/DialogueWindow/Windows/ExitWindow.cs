using PlayerInput;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DialogueWindow
{
    public class ExitWindow : AbstractDialogueWindow
    {
        [SerializeField] private Button _yes;
        [SerializeField] private Button _no;

        [Inject]
        private void Constrct(InputHandler inputHandler)
        {
            inputHandler.Block();
            
            _yes.onClick.AddListener(Application.Quit);
            _no.onClick.AddListener(() =>
            {
                inputHandler.Unblock();
                Destroy(gameObject);
            });
        }
    }
}