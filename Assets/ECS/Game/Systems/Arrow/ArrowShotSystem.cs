using DataBase.FX;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems.Arrow
{
    public class ArrowShotSystem : ReactiveSystem<ShotEventComponent>
    {
        private readonly EcsWorld _world;
        protected override EcsFilter<ShotEventComponent> ReactiveFilter { get; }
        private readonly EcsFilter<PositionComponent, RotationComponent, ArrowComponent>.Exclude<IsAvailableComponent> _arrows;
        protected override bool DeleteEvent => false;
        protected override void Execute(EcsEntity entity)
        {
            foreach (var i in _arrows)
            {
                var arrowEntity = _arrows.GetEntity(i);
                arrowEntity.Get<IsAvailableComponent>();
                arrowEntity.Get<EventAddComponent<IsAvailableComponent>>();

                ref var position = ref _arrows.Get1(i).Value;
                position = entity.Get<PositionComponent>().Value;         //start pos
                
                ref var rotation = ref _arrows.Get2(i).Value;
                rotation = entity.Get<RotationComponent>().Value;         //start rot

                var owner = _world.GetEntityWithUid(entity.Get<OwnerComponent>().Value);
                arrowEntity.Get<OwnerComponent>().Value = entity.Get<OwnerComponent>().Value;
                
                if (owner.Has<TargetComponent>())
                    arrowEntity.Get<TargetComponent>().value = owner.Get<TargetComponent>().value;
                else 
                    arrowEntity.Get<TargetPositionComponent>().Value = position + (rotation * Vector3.forward) * 10;
                break;
            }
            entity.Destroy();
        }
    }
}