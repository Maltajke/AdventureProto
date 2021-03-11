using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems.Arrow
{
    public class ArrowMoveSystem : IEcsUpdateSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<PositionComponent, TargetPositionComponent, ArrowComponent, IsAvailableComponent> _availableArrows;
        public void Run()
        {
            foreach (var i in _availableArrows)
            {
                ref var currentPos = ref _availableArrows.Get1(i).Value;
                ref var targetPos = ref _availableArrows.Get2(i).Value;
                currentPos = Vector3.MoveTowards(currentPos, targetPos, 5 * Time.deltaTime); //Set speed!
            }
        }
    }
}