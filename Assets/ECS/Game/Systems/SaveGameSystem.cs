using System;
using System.Collections.Generic;
using ECS.Core.Utils.ReactiveSystem;
using ECS.DataSave;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Listeners;
using Game.SceneLoading;
using Leopotam.Ecs;
using PdUtils.Dao;
using Utils.SeparateThreadExecutor.Impl;
using Zenject;

namespace ECS.Game.Systems
{
    public class SaveGameSystem : ReactiveSystem<SaveGameEventComponent>
    {
        [Inject] private readonly IDao<GameState> _gameStateDao;
        [Inject] private readonly IDao<GeneralState> _generalStateDao;
        [Inject] private readonly IMemoryPool<GameState> _pool;
        [Inject] private readonly ISceneLoadingManager _sceneLoadingManager;
        
        private readonly EcsWorld _world;

        private readonly EcsFilter<UIdComponent> _entities;
        protected override EcsFilter<SaveGameEventComponent> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            var thread = new DefaultSeparateThreadExecutor();
            var generalState = _pool.Spawn();
            generalState.States = new List<SaveState>();
            generalState.SceneKey = _sceneLoadingManager.CurrentScene;
            thread.Execute(() =>
            {
                var genState = new GeneralState { Scene = _sceneLoadingManager.CurrentScene};
                _generalStateDao.Save(genState);
                foreach (var i in _entities)
                {
                    var components = new SaveState();
                    components.WriteState(_entities.GetEntity(i));
                    generalState.States.Add(components);
                }
                GC.Collect();
            }, () =>
            {
                _gameStateDao.Save(generalState);
            });
        }
    }
}