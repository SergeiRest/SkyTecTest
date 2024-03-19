using PlayerInput;
using TicTacToe.Grid;
using TicTacToe.Timer;
using Zenject;

namespace TicTacToe
{
    public class GameInitializer
    {
        private GridFactory _gridFactory;

        [Inject] private SelectionChecker _selectionChecker;
        [Inject] private RoundTimer _timer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _gridFactory = new GridFactory();
            diContainer.Inject(_gridFactory);
        }

        public void Initialize()
        {
            _gridFactory.Create();
            _selectionChecker.Initialize();
        }
        
        public void Dispose()
        {
            _gridFactory.Clear();
            _timer.Stop();
        }
    }
}