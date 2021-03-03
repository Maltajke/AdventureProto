using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components.Flags;
using Game.Ui.LocationChoise;
using Leopotam.Ecs;
using Services.Input;
using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace ECS.Game.Systems
{
    public class NpcInteractSystem : IEcsUpdateSystem
    {
        [Inject] private readonly IInputManager _inputManager;
        [Inject] private readonly SignalBus _signalBus;
        private readonly EcsFilter<NpcComponent, InteractComponent> _npc;
        public void Run()
        {
            foreach (var i in _npc)
            {
                if(_inputManager.PlayerInteract())
                {
                    _signalBus.OpenWindow<LocationChoiseWindow>();
                }
            }
        }
    }
}