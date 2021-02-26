using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Views.Impls.Character;
using Leopotam.Ecs;

namespace ECS.Game.Systems.Linked
{
    public class PositionRotationTranslateSystem : IEcsUpdateSystem
    {
        private readonly EcsFilter<PositionComponent,RotationComponent, LinkComponent> _views;
        public void Run()
        {
            foreach (var i in _views)
            {
                ref var pos = ref _views.Get1(i).Value;
                ref var rot = ref _views.Get2(i).Value;
                var transform = _views.Get3(i).View.Transform;
                transform.position = pos;
                transform.rotation = rot;
            }
        }
    }
}