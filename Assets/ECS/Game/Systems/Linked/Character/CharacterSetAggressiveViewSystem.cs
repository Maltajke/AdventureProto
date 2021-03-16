using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked.Character
{
    public class CharacterSetAggressiveViewSystem : ReactiveSystem<EventAddComponent<InSafeAreaComponent>, EventRemoveComponent<InSafeAreaComponent>>
    {
        protected override EcsFilter<EventAddComponent<InSafeAreaComponent>> ReactiveFilter { get; }
        protected override EcsFilter<EventRemoveComponent<InSafeAreaComponent>> ReactiveFilter2 { get; }
        protected override void Execute(EcsEntity entity, bool added)
        {
            var view = (MainPlayerView) entity.Get<LinkComponent>().View;
            view.SetAggressState(!added);
        }
    }
}