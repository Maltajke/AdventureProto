using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked
{
    public class CharacterUnsetAggressiveSystem : ReactiveSystem<EventRemoveComponent<InSafeAreaComponent>>
    {
        protected override EcsFilter<EventRemoveComponent<InSafeAreaComponent>> ReactiveFilter { get; }
        protected override bool EntityFilter(EcsEntity entity) => entity.Has<PlayerComponent>();
        protected override void Execute(EcsEntity entity)
        {
            var view = (MainPlayerView) entity.Get<LinkComponent>().View;
            view.SetAggressState(true);
        }
    }
}