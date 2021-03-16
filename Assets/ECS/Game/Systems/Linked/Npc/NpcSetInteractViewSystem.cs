﻿using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked.Npc
{
    public class NpcSetInteractViewSystem : ReactiveSystem<EventAddComponent<InteractComponent>, EventRemoveComponent<InteractComponent>>
    {
        protected override EcsFilter<EventAddComponent<InteractComponent>> ReactiveFilter { get; }
        protected override EcsFilter<EventRemoveComponent<InteractComponent>> ReactiveFilter2 { get; }
        protected override bool EntityFilter(EcsEntity entity) => entity.Has<NpcComponent>();
        protected override void Execute(EcsEntity entity, bool added)
        {
            var view = (NpcView)entity.Get<LinkComponent>().View;
            view.SetEnableInteract(added);
        }
    }
}