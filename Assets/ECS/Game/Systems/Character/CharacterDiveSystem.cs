using DataBase.Character;
using DataBase.Game;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Services.Input;
using UnityEngine;
using Zenject;

namespace ECS.Game.Systems.Character
{
    public class CharacterDiveSystem : ReactiveSystem<DiveComponent>
    {
        private readonly EcsFilter<GameStageComponent> _gameStage;
        [Inject] private readonly ICharacterSettingsBase _characterSettingsBase;
        protected override EcsFilter<DiveComponent> ReactiveFilter { get; }
        protected override bool DeleteEvent() => false;
        protected override void Execute(EcsEntity entity)
        {
            if (entity.Has<InSafeAreaComponent>())
            {
                entity.Del<DiveComponent>();
                entity.Del<EventAddComponent<DiveComponent>>();
                return;
            }
            if(_gameStage.Get1(0).Value == EGameStage.Pause) return;
            ref var position = ref entity.Get<PositionComponent>().Value;
            ref var rotation = ref entity.Get<RotationComponent>().Value;
            var inputValue = rotation * Vector3.forward;
            var moveSpeed = _characterSettingsBase.CharacterSettings.MoveSpeed;
            EcsExtensions.MovePlayerOnNavMesh(inputValue, ref position, ref rotation, moveSpeed*2);
        }
    }
}