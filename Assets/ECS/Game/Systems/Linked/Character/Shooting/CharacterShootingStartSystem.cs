using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked.Character.Shooting
{
    public class CharacterShootingStartSystem : ReactiveSystem<StateMachineCallbackStart<ShootingComponent>>
    {
        protected override EcsFilter<StateMachineCallbackStart<ShootingComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            entity.Del<ShootingComponent>();
            var link = (MainPlayerView) entity.Get<LinkComponent>().View;
            link.SetShooting(false);
        }
    }
}