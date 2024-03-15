using TicTacToe.Grid;
using Zenject;

namespace TicTacToe
{
    public class GameInitializer
    {
        private GridFactory _gridFactory;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _gridFactory = new GridFactory();
            diContainer.Inject(_gridFactory);
        }

        public void Initialize()
        {
            _gridFactory.Create();
        }
    }
}