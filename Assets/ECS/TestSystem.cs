using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.SystemInterfaces;
using Leopotam.Ecs;
using Services;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

#pragma warning disable 649
#pragma warning disable 169

namespace ECS
{
    public sealed class TestSystem : IEcsUpdateSystem
    {
        [Inject] private readonly ITestService _testService;
        private readonly EcsWorld _world;

        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var entity = _world.NewEntity();
                entity.Get<DefaultComponent>();
                entity.Get<SomeOneFrameComponent>().Value = Random.Range(0, 255);
            }
        }
    }    
    
    public sealed class TestSystem2 : ReactiveSystem<SomeOneFrameComponent>
    {
        protected override EcsFilter<SomeOneFrameComponent> ReactiveFilter { get; }

        protected override bool EntityFilter(EcsEntity entity) =>
            entity.Has<DefaultComponent>();

        [Inject] private readonly ITestService _testService;
        private readonly EcsWorld _world;

        protected override void Execute(EcsEntity entity)
        {
            Debug.Log(entity.Get<SomeOneFrameComponent>().Value);
        }
    }
}