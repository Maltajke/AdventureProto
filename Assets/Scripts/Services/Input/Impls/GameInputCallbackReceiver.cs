using System;
using ECS.Game.Components.Events;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using SimpleUi.Signals;
using UnityEngine.InputSystem;
using Zenject;

namespace Services.Input.Impls
{
    public class GameInputCallbackReceiver : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly EcsWorld _world;
        private readonly IInputManager _inputManager;

        public GameInputCallbackReceiver(SignalBus signalBus, EcsWorld world, IInputManager inputManager)
        {
            _signalBus = signalBus;
            _world = world;
            _inputManager = inputManager;
        }

        public void Initialize()
        {
            _inputManager.Actions.Player.Menu.started += MenuOnStarted;
            _inputManager.Actions.Player.Interact.started += InteractOnStarted;
            _inputManager.Actions.Player.Dive.started += DiveOnstarted;
        }

        public void Dispose()
        {
            _inputManager.Actions.Player.Menu.started -= MenuOnStarted;
            _inputManager.Actions.Player.Interact.started -= InteractOnStarted;
            _inputManager.Actions.Player.Dive.started -= DiveOnstarted;
        }

        private void DiveOnstarted(InputAction.CallbackContext obj)
        {
            
        }

        private void InteractOnStarted(InputAction.CallbackContext obj)
        {
            _world.NewEntity().Get<InteractEventComponent>();
        }

        private void MenuOnStarted(InputAction.CallbackContext obj)
        {
            _signalBus.OpenWindow<InGameMenuWindow>();
        }
    }
}