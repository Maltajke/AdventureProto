using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Behaviours
{
    public class StateMachineEcsReceiver<T> : StateMachineBehaviour where T : struct
    {
        
        [Inject] private readonly EcsWorld _world;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _world.GetPlayer().Get<StateMachineCallbackStart<T>>();
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            _world.GetPlayer().Get<StateMachineCallbackEnd<T>>();
        }
    }
}