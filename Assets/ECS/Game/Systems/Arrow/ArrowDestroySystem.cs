using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems.Arrow
{
    public class ArrowDestroySystem : IEcsUpdateSystem
    {
        private readonly EcsFilter<PositionComponent, TargetPositionComponent, ArrowComponent, IsAvailableComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                ref var pos = ref _filter.Get1(i).Value;
                ref var targetPos = ref _filter.Get2(i).Value;
                if (pos != targetPos) continue;

                Debug.Log("DEAL DAMAGE!");
                entity.Del<IsAvailableComponent>();
                entity.Get<EventRemoveComponent<IsAvailableComponent>>();
                entity.Del<TargetPositionComponent>();
                entity.Del<OwnerComponent>();
            }
        }
    }
}