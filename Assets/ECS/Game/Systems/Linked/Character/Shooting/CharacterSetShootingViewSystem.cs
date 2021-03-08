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
    public class CharacterSetShootingViewSystem : ReactiveSystem<EventAddComponent<ShootingComponent>>
    {
        [Inject] private IInputManager _inputManager;
        protected override EcsFilter<EventAddComponent<ShootingComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            if (entity.Has<InSafeAreaComponent>()) return;
            _inputManager.MoveEnable(false);
            entity.Get<ShootingComponent>();
            var link = (MainPlayerView) entity.Get<LinkComponent>().View;
            link.SetShooting(true);
        }
    }
}