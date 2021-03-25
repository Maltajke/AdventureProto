using System;
using System.Collections.Generic;
using ECS.Core.Utils.ReactiveSystem;
using ECS.DataSave;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Listeners;
using Leopotam.Ecs;
using PdUtils.Dao;
using Utils.SeparateThreadExecutor.Impl;
using Zenject;

namespace ECS.Game.Systems
{
    public class SaveGameSystem : ReactiveSystem<SaveGameEventComponent>
    {
        [Inject] private readonly IDao<GeneralState> _generalStateDao;
        [Inject] private readonly IMemoryPool<GeneralState> _pool;
        
        private readonly EcsWorld _world;

        private readonly EcsFilter<UIdComponent> _entities;
        protected override EcsFilter<SaveGameEventComponent> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            var thread = new DefaultSeparateThreadExecutor();
            var generalState = _pool.Spawn();
            generalState.states = new List<State>();
            thread.Execute(() =>
            {
                foreach (var i in _entities)
                {
                    var state = new State(new List<object>());
                    var indxComp = new object[256];
                    _entities.GetEntity(i).GetComponentValues(ref indxComp);
                    foreach (var j in indxComp)
                    {
                        if (j != null && !(j is LinkComponent) && !(j is IListener))
                        {
                            state._components.Add(j);
                        }
                    }
                    generalState.states.Add(state);
                }
                GC.Collect();
            }, () =>
            {
                _generalStateDao.Save(generalState);
            });
        }
    }
}