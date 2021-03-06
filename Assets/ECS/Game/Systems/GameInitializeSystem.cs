using ECS.Utils.Extensions;
using Game.Utils.MonoBehUtils;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Game.Systems
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        [Inject] private readonly GetPointFromScene _getPointFromScene;
        private readonly EcsWorld _world;
        public void Init()
        {
            CreatePlayer();
            CreateCamera();
            CreateEnemies(10);
            CreateNPC();
            CreateLevel();
        }

        private void CreatePlayer()
        {
            var transform = _getPointFromScene.GetPoint("Player");
            _world.CreatePlayer(transform.position);
        }

        private void CreateCamera()
        {
            _world.CreateCamera();
        }

        private void CreateLevel()
        {
            _world.CreateLevel(_getPointFromScene.GetSaveArea);
        }

        private void CreateEnemies(int count)
        {
            for (int i = 0; i < count; i++)
                _world.CreateEnemy(_getPointFromScene.GetRandomPoint());
        }

        private void CreateNPC()
        {
            var transform = _getPointFromScene.GetPoint("MainNPC");
            _world.CreateNPC(transform.position, transform.rotation);
        }
    }
}