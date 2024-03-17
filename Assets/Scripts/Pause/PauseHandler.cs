using DefaultNamespace.DialogueWindow;
using UnityEngine;
using Zenject;

namespace Pause
{
    public class PauseHandler
    {
        [Inject] private DialogueWindowPresenter _dialogueWindowPresenter;

        public void Pause()
        {
            Debug.Log("Pause");
            _dialogueWindowPresenter.Show<PauseWindow>();
            //Time.timeScale = 0;
        } 
        public void Unpause() => Time.timeScale = 1;
    }
}