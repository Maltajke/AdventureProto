using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked.Character.Shooting
{
    public class CharacterShootingStartSystem : ReactiveSystem<StateMachineCallbackStart<IsShootingComponent>>
    {
        protected override EcsFilter<StateMachineCallbackStart<IsShootingComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            entity.Del<IsShootingComponent>();
            var link = (MainPlayerView) entity.Get<LinkComponent>().View;
            link.SetShooting(false);
        }
    }
}