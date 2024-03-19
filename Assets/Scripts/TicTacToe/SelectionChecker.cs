using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DialogueWindow;
using LoadingScreen;
using TicTacToe.Grid;
using UnityEngine;
using Zenject;

namespace TicTacToe
{
    public class SelectionChecker
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private SpriteData _spriteData;
        [Inject] private DialogueWindowPresenter _dialogueWindowPresenter;
        
        private Dictionary<Type, ITurn> _turns = new Dictionary<Type, ITurn>();
        private ITurn current;
        private GridCalculator _gridCalculator;
        
        [Inject] private void Construct()
        {
            _gridCalculator = new GridCalculator();
            
            ITurn player = new PlayerTurn(_spriteData.GetSprite("Cross"));
            ITurn bot = new BotTurn(_spriteData.GetSprite("TAC-toe"));
            
            _turns.Add(player.GetType(), player);
            _turns.Add(bot.GetType(), bot);

            //current = player;
        }

        public void Initialize()
        {
            foreach (var turn in _turns)
            {
                _diContainer.Inject(turn.Value);
            }
            
            _diContainer.Inject(_gridCalculator);
            if(_turns.TryGetValue(typeof(PlayerTurn), out var newTurn))
            {
                current = newTurn;
            }
        }

        public void Check(ICell cell, Type from)
        {
            if(current == null || from != current.GetType())
                return;
            
            if(cell.Picked != Pick.None)
                return;
            
            cell.Select(current.Pick);
            cell.UpdateView(current.Active);
            if (!_gridCalculator.IsAvailable(current.Pick))
            {
                current = _turns.First(type => type.Key != from).Value;
                current.Activate();
            }
            else
            {
                switch (current.Pick)
                {
                    case Pick.Bot:
                        _dialogueWindowPresenter.Show<LoseWindow>();
                        break;
                    case Pick.Player:
                        _dialogueWindowPresenter.Show<WinWindow>();
                        break;
                }
                current = null;
            }
        }
    }
}