using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using Services.Input;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Zenject;

namespace ECS.Game.Systems.Character
{
    public class CharacterMoveSystem : IEcsUpdateSystem
    {
        [Inject] 
        private readonly IInputManager _inputManager;
        private readonly EcsFilter<PositionComponent, PlayerComponent> _player;

        public void Run()
        {
            foreach (var i in _player)
            {
                var inputValue = _inputManager.InputValue;
                ref var position = ref _player.Get1(i).Value;
                if (inputValue.sqrMagnitude >= .01f)
                {
                    var newPos = position + inputValue * Time.deltaTime * 10f;
                    NavMeshHit hit;
                    var isValid = NavMesh.SamplePosition(newPos, out hit, .3f, NavMesh.AllAreas);
                    if (isValid)
                    {
                        if ((position - hit.position).magnitude >= .02f)
                            position = hit.position;
                    }
                }
            }
        }
    }
}