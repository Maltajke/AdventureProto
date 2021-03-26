using System.Collections.Generic;
using DataBase.FX;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.DataSave;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Game.SceneLoading;
using Game.Utils.MonoBehUtils;
using Leopotam.Ecs;
using PdUtils.Dao;
using UnityEngine;
using Zenject;

namespace ECS.Game.Systems
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        [Inject] private readonly IDao<GameState> _generalStateDao;
        [Inject] private readonly IMemoryPool<GameState> _pool;
        [Inject] private readonly GetPointFromScene _getPointFromScene;
        [Inject] private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly EcsWorld _world;
        public void Init()
        {
            CreateGameStage();
            
            var isLoaded = false;
            var gState = _pool.Spawn();
            gState.States = new List<SaveState>();
            gState = _generalStateDao.Load();
            if (gState != null)
            {
                if (gState.SceneKey == _sceneLoadingManager.CurrentScene)
                {
                    foreach (var state in gState.States)
                    {
                        var entity =_world.NewEntity();
                        state.ReadState(entity);
                        isLoaded = true;
                    }
                    if (isLoaded) return;
                }
            }

            CreatePlayer();
            CreateCamera();
            CreateEnemies(150);
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
                _world.CreateArrow(Vector3.zero + new Vector3(0,1000,0));
        }


        private void CreateNPC()
        {
            var transform = _getPointFromScene.GetPoint("MainNPC");
            _world.CreateNPC(transform.position, transform.rotation);
        }
    }
}