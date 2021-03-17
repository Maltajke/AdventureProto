using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Game.Components.AI;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Services.AI;
using Zenject;

namespace ECS.Game.Systems.AI
{
    public class CalculatePathSystem : ReactiveSystem<TargetComponent>
    {
        [Inject] private IPathCalculator _pathCalculator;
        private readonly EcsWorld _world;
        protected override EcsFilter<TargetComponent> ReactiveFilter { get; }
        protected override bool DeleteEvent => false;
        protected override bool EntityFilter(EcsEntity entity) => entity.Has<AiComponent>();
        protected override void Execute(EcsEntity entity)
        {
            ref var pos = ref entity.Get<PositionComponent>().Value;
            ref var posTarget = ref _world.GetEntityWithUid(entity.Get<TargetComponent>().value).Get<PositionComponent>().Value;
            ref var path = ref entity.Get<PathComponent>().Value;
            path = _pathCalculator.CalculatePath(pos, posTarget);
        }
    }
}