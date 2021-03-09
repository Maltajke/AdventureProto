using ECS.Core.Utils.ReactiveSystem.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Behaviours
{
    public class StateMachineEcsReceiver<T> : StateMachineBehaviour, IEcsBehaviourReceiver where T : struct
    {
        public EcsEntity Entity { get; set; }
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            Entity.Get<StateMachineCallbackStart<T>>();
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            Entity.Get<StateMachineCallbackEnd<T>>();
        }
    }
}