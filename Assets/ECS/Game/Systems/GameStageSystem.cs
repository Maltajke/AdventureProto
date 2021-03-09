using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using Leopotam.Ecs;

namespace ECS.Game.Systems
{
    public class GameStageSystem : ReactiveSystem<ChangeStageComponent>
    {
        protected override EcsFilter<ChangeStageComponent> ReactiveFilter { get; }
        protected override bool DeleteEvent() => false;
        protected override void Execute(EcsEntity entity)
        {
            ref var stage = ref ReactiveFilter.Get1(0).Value;
            entity.Get<GameStageComponent>().Value = stage;
        }
    }
}