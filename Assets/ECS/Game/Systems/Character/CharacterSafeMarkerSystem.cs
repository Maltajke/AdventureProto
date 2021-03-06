using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Game.Utils;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Game.Systems.Character
{
    public class CharacterSafeMarkerSystem : IEcsUpdateSystem
    {
        private readonly EcsFilter<PlayerComponent, PositionComponent> _player;
        private readonly EcsFilter<LevelComponent, SafeAreaComponent> _safeArea;
        public void Run()
        {
            foreach (var i in _safeArea)
            {
                ref var pos = ref  _player.Get2(0).Value;
                ref var area = ref _safeArea.Get2(i);
                var player = _player.GetEntity(i);
                var hasComponent = player.Has<InSafeAreaComponent>();
                if (pos.ValidatePoint(area.firstPoint, area.secondPoint))
                {
                    if (!hasComponent)
                    {
                        player.Get<InSafeAreaComponent>();
                        player.Get<EventAddComponent<InSafeAreaComponent>>();
                    }
                    else return;
                }
                else if (hasComponent)
                {
                    player.Del<InSafeAreaComponent>();
                    player.Get<EventRemoveComponent<InSafeAreaComponent>>();
                }
            }
        }
    }
}