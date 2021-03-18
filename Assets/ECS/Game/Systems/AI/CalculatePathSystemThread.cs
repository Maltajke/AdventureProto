using ECS.Game.Components;
using ECS.Game.Components.AI;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using Leopotam.Ecs.Threads;
using UnityEngine.AI;

namespace ECS.Game.Systems.AI
{
    public class CalculatePathSystemThread : EcsMultiThreadSystem<EcsFilter<TargetPositionComponent, AiComponent>>
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<TargetPositionComponent, AiComponent> _filter = null;
        protected override EcsFilter<TargetPositionComponent, AiComponent> GetFilter () => _filter;
        protected override int GetMinJobSize() => 10;
        protected override int GetThreadsCount() => 20;
        protected override EcsMultiThreadWorker GetWorker() => Worker;
        static void Worker(EcsMultiThreadWorkerDesc workerDesc)
        {
            foreach (var i in workerDesc)
            {
                //var entity = workerDesc.Filter.GetEntity(i);
                //ref var c = ref workerDesc.Filter.Get1(i);
                //ref var pos = ref entity.Get<PositionComponent>().Value;
                //ref var targetPos = ref entity.Get<TargetPositionComponent>().Value;
                //ref var path = ref entity.Get<PathComponent>().Value;
                //var NavmeshPath = new NavMeshPath();
                //NavMesh.CalculatePath(pos, targetPos, NavMesh.AllAreas, NavmeshPath);
                //path = NavmeshPath.corners;
            }
        }
    }
}