using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Events;
using Leopotam.Ecs;
using Services.Input;
using Zenject;

namespace ECS.Game.Systems.Linked
{
    public class CharacterEndDiveSystem : ReactiveSystem<StateMachineCallbackEnd<DiveComponent>>
    {
        [Inject] private IInputManager _inputManager;
        protected override EcsFilter<StateMachineCallbackEnd<DiveComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            entity.Del<DiveComponent>();
            if(entity.Has<ShootingComponent>()) return;
            _inputManager.MoveEnable(true);
        }
    }
}