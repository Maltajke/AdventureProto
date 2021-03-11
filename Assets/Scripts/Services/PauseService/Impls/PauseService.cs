using System.Collections.Generic;
using DataBase.Game;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Services.Input;
using UnityEngine;
using Zenject;

namespace Services.PauseService.Impls
{
    public class PauseService : IPauseService
    {
        private readonly EcsWorld _world;
        private readonly IInputManager _inputManager;
        private readonly IList<IPause> _pauseListeners;

        public PauseService(EcsWorld world, IInputManager inputManager)
        {
            _world = world;
            _inputManager = inputManager;
            _pauseListeners = new List<IPause>();
        }
        
        public void PauseGame(bool value)
        {
            foreach (var p in _pauseListeners)
                if(value) p.Pause();
                else p.UnPause();
            _inputManager.PlayerEnable(!value);
            _world.GetGameStage().Get<ChangeStageComponent>().Value = value?  EGameStage.Pause : EGameStage.Play;
        }
        
        public void AddPauseListener(IPause pause) => _pauseListeners.Add(pause);
    }
}