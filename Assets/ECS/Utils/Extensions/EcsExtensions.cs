using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;

namespace ECS.Utils.Extensions
{
    public static class EcsExtensions
    {

        public static EcsEntity? GetPlayer(this EcsWorld world)
        {
            var filter = world.GetFilter(typeof(EcsFilter<PlayerComponent, PositionComponent>));
            foreach(var i in filter)
            {
                return filter.GetEntity(i);
            }
            return null;
        }
        public static void DeclareOneFrameEvents(this EcsSystems systems)
        {
            systems.OneFrame<PrefabComponent>();
            systems.OneFrame<InteractEventComponent>();
        }
    }
}