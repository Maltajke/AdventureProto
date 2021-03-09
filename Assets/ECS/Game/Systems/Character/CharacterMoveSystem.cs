using DataBase.Character;
using DataBase.Game;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
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
        private readonly EcsFilter<GameStageComponent> _gameStage;

        public void Run()
        {
            if(_gameStage.Get1(0).Value == EGameStage.Pause) return;
            foreach (var i in _player)
            {
                var inputValue = _inputManager.InputValue;
                ref var position = ref _player.Get2(i).Value;
                ref var rotation = ref _player.Get3(i).Value;
                var moveSpeed = _characterSettingsBase.CharacterSettings.MoveSpeed;
                var rotateSpeed = 1;
                if (!_player.GetEntity(i).Has<InSafeAreaComponent>())
                {
                    moveSpeed += 2;
                    rotateSpeed = 2;
                }
                EcsExtensions.MovePlayerOnNavMesh(inputValue, ref position, ref rotation, moveSpeed, rotateSpeed);
            }
        }
    }
}