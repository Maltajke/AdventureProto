using DataBase.Game;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems.Arrow
{
    public class ArrowMoveSystem : IEcsUpdateSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<PositionComponent, TargetPositionComponent, ArrowComponent, IsAvailableComponent> _availableArrows;
        private readonly EcsFilter<GameStageComponent> _gameStage;
        private bool _pause => _gameStage.Get1(0).Value == EGameStage.Pause;
        public void Run()
        {
            if (_pause) return;
            foreach (var i in _availableArrows)
            {
                ref var currentPos = ref _availableArrows.Get1(i).Value;
                ref var targetPos = ref _availableArrows.Get2(i).Value;
                var offset = new Vector3(targetPos.x, currentPos.y, targetPos.z);
                currentPos = Vector3.MoveTowards(currentPos, offset, 25 * Time.deltaTime); //Set speed!
            }
        }
    }
}