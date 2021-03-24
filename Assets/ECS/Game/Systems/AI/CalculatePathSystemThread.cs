using ECS.Game.Components;
using ECS.Game.Components.AI;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Leopotam.Ecs.Threads;

namespace ECS.Game.Systems.AI
{
    public class CalculatePathSystemThread : EcsMultiThreadSystem<EcsFilter<TargetPositionComponent, AiComponent>>
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<TargetPositionComponent, AiComponent> _filter = null;
        protected override EcsFilter<TargetPositionComponent, AiComponent> GetFilter () => _filter;
        protected override int GetMinJobSize() => 5;
        protected override int GetThreadsCount() => 40;
        protected override EcsMultiThreadWorker GetWorker() => Worker;
        private void Worker(EcsMultiThreadWorkerDesc workerDesc)
        {
            foreach (var i in workerDesc)
            {
                var entity = workerDesc.Filter.GetEntity(i);
                ref var targetPos = ref workerDesc.Filter.Get1(i).Value;
                ref var pos = ref entity.Get<PositionComponent>().Value;
                ref var path = ref entity.Get<PathComponent>();
                path.Value.CalculateRandomPath(pos, targetPos);
            }
        }
    }
}