using ECS.Core.Utils.SystemInterfaces;
using Leopotam.Ecs;

namespace ECS.Core.Utils.ReactiveSystem
{
    public abstract class ReactiveSystem<T>  : IEcsUpdateSystem where T : struct
    {
        protected abstract EcsFilter<T> ReactiveFilter { get; }
        protected abstract bool EntityFilter(EcsEntity entity);
        public void Run()
        {
            foreach (var i in ReactiveFilter)
            {
                var entity = ReactiveFilter.GetEntity(i);
                if (EntityFilter(entity))
                    Execute(entity);
            }
                
        }
        protected abstract void Execute(EcsEntity entity);
    }
}