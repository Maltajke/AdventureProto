using System.Collections.Generic;
using ECS.Core.Utils.SystemInterfaces;
using Leopotam.Ecs;
using Zenject;

namespace ECS
{
    public class EcsMainBootstrap : IInitializable, ITickable, ILateTickable, IFixedTickable
    {
        private readonly EcsWorld _world;
        private readonly EcsSystems _updateSystems;
        private readonly EcsSystems _fixedUpdateSystems;
        private readonly EcsSystems _lateUpdateSystems;

        public EcsMainBootstrap(
            IList<IEcsUpdateSystem> updateSystems,
            IList<IEcsFixedSystem> fixedSystemsSystems,
            IList<IEcsLateSystem> lateSystems)
        {
            _world = new EcsWorld();

            if (updateSystems.Count > 0)
            {
                _updateSystems = new EcsSystems(_world);
                _updateSystems.AddRange(updateSystems);
            }
            if (fixedSystemsSystems.Count > 0)
            {
                _fixedUpdateSystems = new EcsSystems(_world);
                _fixedUpdateSystems.AddRange(updateSystems);
            }

            if (lateSystems.Count > 0)
            {
                _lateUpdateSystems = new EcsSystems(_world);
                _lateUpdateSystems.AddRange(updateSystems);
            }

            _updateSystems.OneFrame<SomeOneFrameComponent>();
        }

        public void Initialize()
        {
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_updateSystems);
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
#endif  
            _updateSystems?.Init();
            _fixedUpdateSystems?.Init();
            _lateUpdateSystems?.Init();
        }

        public void Tick()
        {
            _updateSystems?.Run();
        }

        public void FixedTick()
        {
            _fixedUpdateSystems?.Run();
        }
        
        public void LateTick()
        {
            _lateUpdateSystems?.Run();
        }
    }
}
