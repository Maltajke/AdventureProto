using DataBase.Character;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using Services.Input;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ECS.Game.Systems.Character
{
    public class CharacterMoveSystem : IEcsUpdateSystem
    {
        [Inject] private readonly IInputManager _inputManager;
        [Inject] private readonly ICharacterSettingsBase _characterSettingsBase;
        private readonly EcsFilter<PlayerComponent, PositionComponent, RotationComponent> _player;

        public void Run()
        {
            foreach (var i in _player)
            {
                var inputValue = _inputManager.InputValue;
                ref var position = ref _player.Get2(i).Value;
                ref var rotation = ref _player.Get3(i).Value;
                if (inputValue.sqrMagnitude >= .01f)
                {
                    var moveSpeed = _characterSettingsBase.CharacterSettings.MoveSpeed;
                    if (!_player.GetEntity(i).Has<InSafeAreaComponent>())
                        moveSpeed += 2;
                    var newPos = position + inputValue * Time.deltaTime * moveSpeed;
                    var isValid = NavMesh.SamplePosition(newPos, out var hit, .3f, NavMesh.AllAreas);
                    if (isValid)
                    {
                        if ((position - hit.position).magnitude >= .02f)
                            position = hit.position;
                    }
                    
                    var lookDir = new Vector3(inputValue.x, 0, inputValue.z);
                    var toRotation = Quaternion.LookRotation(lookDir, Vector3.up);
                    rotation = Quaternion.RotateTowards(rotation, toRotation, 720 * Time.deltaTime);
                }
            }
        }
    }
}