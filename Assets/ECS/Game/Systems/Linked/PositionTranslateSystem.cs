using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked
{
    public class PositionTranslateSystem : IEcsUpdateSystem
    {
        private readonly EcsFilter<PositionComponent, LinkComponent> _views;
        public void Run()
        {
            foreach (var i in _views)
            {
                ref var pos = ref _views.Get1(i).Value;
                _views.Get2(i).View.Transform.position = pos;
            }
        }
    }
}