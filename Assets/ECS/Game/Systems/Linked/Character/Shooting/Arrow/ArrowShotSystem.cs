using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked.Character.Shooting.Arrow
{
    public class ArrowShotSystem : ReactiveSystem<ShotEventComponent>
    {
        protected override EcsFilter<ShotEventComponent> ReactiveFilter { get; }
        private readonly EcsFilter<PositionComponent, ArrowComponent> _arrows;
        protected override void Execute(EcsEntity entity)
        {
            foreach (var i in _arrows)
            {
                var arrowEntity = _arrows.GetEntity(i);
                if (arrowEntity.Has<IsAvailableComponent>()) return;
                _arrows.Get1(i).Value = ReactiveFilter.Get1(0).startPosition;
                arrowEntity.Get<IsAvailableComponent>();
            }
        }
    }
}