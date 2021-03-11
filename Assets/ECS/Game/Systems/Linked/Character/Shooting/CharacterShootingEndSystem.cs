using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using Leopotam.Ecs;
using Services.Input;
using Zenject;

namespace ECS.Game.Systems.Linked.Character.Shooting
{
    public class CharacterShootingEndSystem : ReactiveSystem<StateMachineCallbackEnd<IsShootingComponent>>
    {
        [Inject] private IInputManager _inputManager;
        protected override EcsFilter<StateMachineCallbackEnd<IsShootingComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            entity.Del<TargetComponent>();
            if (entity.Has<IsShootingComponent>()) return;
            _inputManager.MoveEnable(true);
        }
    }
}