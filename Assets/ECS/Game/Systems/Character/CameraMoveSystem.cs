using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems.Character
{
    public class CameraMoveSystem : IEcsUpdateSystem
    {
        private readonly EcsFilter<CameraComponent, PositionComponent> _camera;
        private readonly EcsFilter<PlayerComponent, PositionComponent> _player;
        
        public void Run()
        {
            ref var movePoint = ref _player.Get2(0).Value;
            ref var cameraPosition = ref _camera.Get2(0).Value;
            var toGo = movePoint + new Vector3(0, 7, -5);
            cameraPosition = Vector3.Lerp(cameraPosition, toGo, 5f * Time.deltaTime);
        }
    }
}