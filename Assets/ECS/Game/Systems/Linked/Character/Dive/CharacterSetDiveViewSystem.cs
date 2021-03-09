using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked
{
    public class CharacterSetDiveViewSystem : ReactiveSystem<EventAddComponent<DiveComponent>>
    {
        protected override EcsFilter<EventAddComponent<DiveComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            var link = (MainPlayerView)entity.Get<LinkComponent>().View;
            link.SetDive(true);
        }
    }
}