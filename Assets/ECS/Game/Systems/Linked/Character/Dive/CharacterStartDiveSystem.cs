using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;
using Services.Input;
using Zenject;

namespace ECS.Game.Systems.Character.Dive
{
    public class CharacterStartDiveSystem : ReactiveSystem<StateMachineCallbackStart<DiveComponent>>
    {
        [Inject] private IInputManager _inputManager;
        protected override EcsFilter<StateMachineCallbackStart<DiveComponent>> ReactiveFilter { get; }

        protected override void Execute(EcsEntity entity)
        {
            var link = (MainPlayerView) entity.Get<LinkComponent>().View;
            link.SetDive(false);
            _inputManager.MoveEnable(false);
        }
    }
}