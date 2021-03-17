using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems.Character
{
    public class CharacterLookAtSystem : ReactiveSystem<TargetComponent>
    {
        private readonly EcsWorld _world;
        protected override EcsFilter<TargetComponent> ReactiveFilter { get; }
        protected override bool EntityFilter(EcsEntity entity) => entity.Has<PlayerComponent>();
        protected override bool DeleteEvent => false;
        protected override void Execute(EcsEntity entity)
        {
            var target = _world.GetEntityWithUid(entity.Get<TargetComponent>().value);
            
            ref var targetPos = ref target.Get<PositionComponent>().Value;
            ref var myPos = ref entity.Get<PositionComponent>().Value;
            ref var rot = ref entity.Get<RotationComponent>().Value;
            
            var lookDir = new Vector3(targetPos.x, 0, targetPos.z) - myPos;
            var toRotation = Quaternion.LookRotation(lookDir.normalized);
            rot = Quaternion.RotateTowards(rot, toRotation, 720  * 2 * Time.deltaTime);
        }
    }
}