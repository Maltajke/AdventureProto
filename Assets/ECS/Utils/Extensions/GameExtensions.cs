using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;

namespace ECS.Utils.Extensions
{
    public static class GameExtensions
    {
        public static EcsEntity CreatePlayer(this EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<PlayerComponent>();
            entity.Get<PositionComponent>();
            entity.Get<RotationComponent>();
            entity.Get<PrefabComponent>().Value = "MainPlayer";
            return entity;

        }
    }
}