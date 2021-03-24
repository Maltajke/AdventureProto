using DataBase.Game;
using ECS.Game.Components.Events;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Services.Input;

namespace Services.PauseService.Impls
{
    public class PauseService : IPauseService
    {
        private readonly EcsWorld _world;
        private readonly IInputManager _inputManager;
        public PauseService(EcsWorld world, IInputManager inputManager)
        {
            _world = world;
            _inputManager = inputManager;
        }
        
        public void PauseGame(bool value)
        {
            _inputManager.PlayerEnable(!value);
            _world.GetGameStage().Get<ChangeStageComponent>().Value = value?  EGameStage.Pause : EGameStage.Play;
        }
    }
}