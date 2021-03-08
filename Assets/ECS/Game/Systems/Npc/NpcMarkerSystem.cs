using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;

namespace ECS.Game.Systems
{
    public class NpcMarkerSystem : IEcsUpdateSystem
    {
        private readonly EcsFilter<NpcComponent, DistanceToPlayerComponent> _npc;
        public void Run()
        {
            foreach (var i in _npc)
            {
                var npcEntity = _npc.GetEntity(i);
                var hasComponent = npcEntity.Has<InteractComponent>();
                if (_npc.Get2(i).Value < 3)
                {
                    if (!hasComponent)
                    {
                        npcEntity.Get<InteractComponent>();
                        npcEntity.Get<EventAddComponent<InteractComponent>>();
                    }
                    else return;
                }
                else if (hasComponent)
                {
                    npcEntity.Del<InteractComponent>();
                    npcEntity.Get<EventRemoveComponent<InteractComponent>>();
                }
            }
        }
    }
}