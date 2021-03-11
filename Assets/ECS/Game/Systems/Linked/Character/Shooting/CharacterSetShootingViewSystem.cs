using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;
using Services.Input;
using Zenject;

namespace ECS.Game.Systems.Linked.Character.Shooting
{
    public class CharacterSetShootingViewSystem : ReactiveSystem<EventAddComponent<IsShootingComponent>>
    {
        [Inject] private IInputManager _inputManager;
        protected override EcsFilter<EventAddComponent<IsShootingComponent>> ReactiveFilter { get; }
        protected override bool DeleteEvent => false;
        protected override void Execute(EcsEntity entity)
        {
            if (entity.Has<InSafeAreaComponent>() || entity.Has<DiveComponent>())
            {
                entity.Del<EventAddComponent<IsShootingComponent>>();
                return;
            }
            _inputManager.MoveEnable(false);
            entity.Get<IsShootingComponent>();
            var link = (MainPlayerView) entity.Get<LinkComponent>().View;
            link.SetShooting(true);
        }
    }
}