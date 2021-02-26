using DataBase.Objects;
using ECS.Game.Components;
using ECS.Views;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Utils.Impls
{
    public class SpawnService : ISpawnService<EcsEntity, ILinkable>
    {
        private readonly DiContainer _container;
        private readonly IPrefabsBase _prefabsBase;

        public SpawnService(
            DiContainer container,
            IPrefabsBase prefabsBase)
        {
            _container = container;
            _prefabsBase = prefabsBase;
        }

        public ILinkable Spawn(EcsEntity entity)
        {
            if (entity.Has<PrefabComponent>())
                return InstantiateLinkable(entity, _prefabsBase.Get(entity.Get<PrefabComponent>().Value));
            throw new System.Exception($"[SpawnService] Can't instantiate entity with uid: " + entity);
        }

        private ILinkable InstantiateLinkable(EcsEntity entity, GameObject prefab)
        {
            var go = _container.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);
            return go.GetComponent<ILinkable>();
        }
    }
}