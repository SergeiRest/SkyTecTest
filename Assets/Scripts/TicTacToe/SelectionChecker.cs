using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
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

            current = player;
        }

        public void Initialize()
        {
            foreach (var turn in _turns)
            {
                _diContainer.Inject(turn.Value);
            }
            
            _diContainer.Inject(_gridCalculator);
        }

        public void Check(ICell cell, Type from)
        {
            if(current == null || from != current.GetType())
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
                current = null;
            }
        }
    }
}