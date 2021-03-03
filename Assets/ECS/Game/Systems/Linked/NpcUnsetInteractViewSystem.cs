using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked
{
    public class NpcUnsetInteractViewSystem : ReactiveSystem<EventRemoveComponent<InteractComponent>>
    {
        protected override EcsFilter<EventRemoveComponent<InteractComponent>> ReactiveFilter { get; }
        protected override bool EntityFilter(EcsEntity entity) => entity.Has<NpcComponent>();
        protected override void Execute(EcsEntity entity)
        {
            var view = (NpcView)entity.Get<LinkComponent>().View;
            view.SetEnableInteract(false);
        }
    }
}