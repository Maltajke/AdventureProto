using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems
{
    public class CalculateDistanceSystem : IEcsUpdateSystem
    {
        private readonly EcsFilter<DistanceToPlayerComponent, PositionComponent> _needDistance;
        private readonly EcsFilter<PlayerComponent, PositionComponent> _player;
        public void Run()
        {
            foreach (var i in _needDistance)
            {
                ref var enemyPos = ref _needDistance.Get2(i).Value;
                ref var playerPos = ref _player.Get2(0).Value;
                var distance = Vector3.Distance(enemyPos, playerPos);
                _needDistance.GetEntity(i).Get<DistanceToPlayerComponent>().Value = distance;
            }
        }
    }
}