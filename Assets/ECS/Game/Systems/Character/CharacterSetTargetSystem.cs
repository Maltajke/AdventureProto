using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Character
{
    public class CharacterSetTargetSystem : ReactiveSystem<EventAddComponent<IsShootingComponent>>
    {
        private readonly EcsFilter<DistanceToPlayerComponent, EnemyComponent> _enemies;
        protected override EcsFilter<EventAddComponent<IsShootingComponent>> ReactiveFilter { get; }
        private EcsEntity ClosestEnemy
        {
            get
            {
                var Entity = new EcsEntity();
                float distance = int.MaxValue;
                foreach (var i in _enemies)
                    if (_enemies.Get1(i).Value < 10) // MAX DISTANCE ENEMY;
                        if (_enemies.Get1(i).Value < distance)
                        {
                            distance = _enemies.Get1(i).Value;
                            Entity = _enemies.GetEntity(i);
                        }
                return Entity;
            }
        }
        protected override void Execute(EcsEntity entity)
        {
            if (ClosestEnemy.IsNull()) return;
            ref var targetId = ref entity.Get<TargetComponent>().value;
            ref var target = ref ClosestEnemy.Get<UIdComponent>().Value;
            targetId = target;
        }
    }
}