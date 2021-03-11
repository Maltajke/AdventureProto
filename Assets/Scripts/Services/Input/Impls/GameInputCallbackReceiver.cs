using System;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Events;
using ECS.Utils.Extensions;
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
            _inputManager.Actions.PlayerInteractions.Menu.started += MenuOnStarted;
            _inputManager.Actions.PlayerInteractions.Interact.started += InteractOnStarted;
            _inputManager.Actions.PlayerInteractions.Dive.started += DiveOnStarted;
            _inputManager.Actions.PlayerInteractions.Fire.started += FireOnstarted;
        }
        
        public void Dispose()
        {
            _inputManager.Actions.PlayerInteractions.Menu.started -= MenuOnStarted;
            _inputManager.Actions.PlayerInteractions.Interact.started -= InteractOnStarted;
            _inputManager.Actions.PlayerInteractions.Dive.started -= DiveOnStarted;
            _inputManager.Actions.PlayerInteractions.Fire.started -= FireOnstarted;
        }

        private void FireOnstarted(InputAction.CallbackContext obj)
        {
            _world.GetPlayer().Get<EventAddComponent<IsShootingComponent>>();
        }

        private void DiveOnStarted(InputAction.CallbackContext obj)
        {
            _world.GetPlayer().Get<DiveComponent>();
            _world.GetPlayer().Get<EventAddComponent<DiveComponent>>();
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