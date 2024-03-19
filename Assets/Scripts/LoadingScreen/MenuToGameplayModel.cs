using LoadingScreen.Config;
using LoadingScreen.Model;
using TicTacToe.Timer;
using Zenject;

namespace LoadingScreen
{
    public class MenuToGameplayModel : BaseLoadingScreenModel
    {
        [Inject] private RoundTimer _timer;

        public override void Dispose()
        {
            _timer.Start();
            base.Dispose();
        }
    }
}