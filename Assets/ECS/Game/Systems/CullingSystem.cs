using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;

namespace ECS.Game.Systems
{
    public class CullingSystem : ReactiveSystem<EnemyComponent>
    {
        protected override EcsFilter<EnemyComponent> ReactiveFilter { get; }
        protected override bool DeleteEvent => false;
        protected override void Execute(EcsEntity entity)
        {
            if (!entity.Has<IsAvailableComponent>() && entity.Get<DistanceToPlayerComponent>().Value <= 30)
            {
                entity.Get<EventAddComponent<IsAvailableComponent>>();
                entity.Get<IsAvailableComponent>();
            }
               
            else if (entity.Has<IsAvailableComponent>() && entity.Get<DistanceToPlayerComponent>().Value >= 30)
            {
                entity.Del<IsAvailableComponent>();
                entity.Get<EventRemoveComponent<IsAvailableComponent>>();
            }
        }
    }
}