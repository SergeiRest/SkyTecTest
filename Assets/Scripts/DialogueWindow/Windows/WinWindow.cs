﻿using DefaultNamespace.Player;
using LoadingScreen.Installer;
using TicTacToe;

namespace DialogueWindow
{
    public class WinWindow :  FinishGameWindow
    {
        public override void Construct(GameInitializer gameInitializer, LoadingScreenProvider loadingProvider, Player player)
        {
            base.Construct(gameInitializer, loadingProvider, player);
            _scoreAnimation.Animate(player.Score.Score, player.Score.Score + 100, UpdateScore, ShowButton);
            player.Score.Increase(100);
        }
    }
}