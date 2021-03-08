using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using Game.Ui.LocationChoise;
using Leopotam.Ecs;
using SimpleUi.Signals;
using Zenject;

namespace ECS.Game.Systems
{
    public class NpcInteractSystem : ReactiveSystem<InteractEventComponent>
    {
        [Inject] private readonly SignalBus _signalBus;
        private readonly EcsFilter<NpcComponent, InteractComponent> _npc;
        protected override EcsFilter<InteractEventComponent> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            if(!_npc.IsEmpty())
                _signalBus.OpenWindow<LocationChoiseWindow>();
        }
    }
}