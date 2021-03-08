using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Events;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Behaviours
{
    public class ShotBehaviour : StateMachineBehaviour
    {
        [Inject] private readonly EcsWorld _world;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _world.GetPlayer().Get<StateMachineCallbackStart<ShootingComponent>>();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _world.GetPlayer().Get<StateMachineCallbackEnd<ShootingComponent>>();
        }
    }
}