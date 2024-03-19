using DialogueWindow;
using UnityEngine;
using Zenject;

namespace PlayerInput
{
    public class InputHandler : ITickable
    {
        [Inject] private DialogueWindowPresenter _windowPresenter;
        
        private bool blocked = false;
        
        public void Tick()
        {
            if(blocked)
                return;
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _windowPresenter.Show<ExitWindow>();
                Debug.Log("Esc");
            }
        }

        public void Block() 
            => blocked = true;

        public void Unblock()
            => blocked = false;
    }
}