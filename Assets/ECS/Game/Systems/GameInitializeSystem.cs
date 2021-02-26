using ECS.Utils.Extensions;
using Leopotam.Ecs;

namespace ECS.Game.Systems
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        public void Init()
        {
            _world.CreatePlayer();
        }
    }
}