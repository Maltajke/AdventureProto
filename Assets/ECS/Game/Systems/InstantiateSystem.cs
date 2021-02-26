using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Utils;
using ECS.Views;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Game.Systems
{
    public class InstantiateSystem : ReactiveSystem<PrefabComponent>
    {
        [Inject] private readonly ISpawnService<EcsEntity, ILinkable> _spawnService;
        protected override EcsFilter<PrefabComponent> ReactiveFilter { get; }
        protected override bool EntityFilter(EcsEntity entity)
        {
            return true;
        }

        protected override void Execute(EcsEntity entity)
        {
            var linkable = _spawnService.Spawn(entity);
            linkable?.Link(entity);
            entity.Get<LinkComponent>().View = linkable;
        }
    }
}