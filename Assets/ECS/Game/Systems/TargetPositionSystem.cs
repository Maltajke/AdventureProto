using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Utils.Extensions;
using Leopotam.Ecs;

namespace ECS.Game.Systems
{
    public class TargetPositionSystem : ReactiveSystem<TargetComponent>
    {
        private readonly EcsWorld _world;
        protected override EcsFilter<TargetComponent> ReactiveFilter { get; }
        protected override bool DeleteEvent => false;
        protected override void Execute(EcsEntity entity)
        {
            ref var targetPos = ref entity.Get<TargetPositionComponent>().Value;
            targetPos = _world.GetEntityWithUid(entity.Get<TargetComponent>().value).Get<PositionComponent>().Value;
        }
    }
}