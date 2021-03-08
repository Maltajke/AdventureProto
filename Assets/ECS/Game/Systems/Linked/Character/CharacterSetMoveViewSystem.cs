using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using ECS.Views.Impls.Character;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;
using Services.Input;
using Zenject;

namespace ECS.Game.Systems.Linked
{
    public class CharacterSetMoveViewSystem : IEcsUpdateSystem
    {
        [Inject] private readonly IInputManager _inputManager;

        private readonly EcsFilter<LinkComponent, PlayerComponent> _player;
        
        public void Run()
        {
            foreach (var i in _player)
            {
                var link = (MainPlayerView)_player.Get1(i).View;
                link.SetMoveValue(_inputManager.InputValue.magnitude);
            }
        }
    }
}