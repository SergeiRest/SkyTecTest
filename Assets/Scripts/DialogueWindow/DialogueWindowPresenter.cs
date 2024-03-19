using Zenject;

namespace DialogueWindow
{
    public class DialogueWindowPresenter
    {
        private DialogueWindowFactory _windowFactory = new DialogueWindowFactory();

        [Inject]
        private void Construct(DiContainer _diContainer)
        {
            _diContainer.Inject(_windowFactory);
        }
        
        public void Show<T>() where T : AbstractDialogueWindow
        {
            _windowFactory.Get<T>();
        }
    }
}