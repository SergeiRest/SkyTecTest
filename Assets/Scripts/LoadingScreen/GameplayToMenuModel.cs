using LoadingScreen.Model;
using PlayerInput;
using TicTacToe.Timer;
using Zenject;

namespace LoadingScreen
{
    public class GameplayToMenuModel : BaseLoadingScreenModel
    {
        [Inject] private InputHandler _input;

        public override void Dispose()
        {
            _input.Unblock();
            base.Dispose();
        }
    }
}