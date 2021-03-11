using ECS.Utils.Extensions;
using Game.Utils.MonoBehUtils;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Game.Systems
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        [Inject] private readonly GetPointFromScene _getPointFromScene;
        private readonly EcsWorld _world;
        public void Init()
        {
            CreateGameStage();
            CreatePlayer();
            CreateCamera();
            CreateEnemies(10);
            CreateNPC();
            CreateLevel();
            CreateArrowPool(20);
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

        private void CreateGameStage()
        {
            _world.CreateGameStage();
        }

        private void CreateEnemies(int count)
        {
            for (int i = 0; i < count; i++)
                _world.CreateEnemy(_getPointFromScene.GetRandomPoint());
        }

        private void CreateArrowPool(int count)
        {
            for (int i = 0; i < count; i++)
                _world.CreateArrow(Vector3.zero);
        }

        private void CreateNPC()
        {
            var transform = _getPointFromScene.GetPoint("MainNPC");
            _world.CreateNPC(transform.position, transform.rotation);
        }
    }
}