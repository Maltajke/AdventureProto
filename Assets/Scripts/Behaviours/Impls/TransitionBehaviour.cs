using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Services.Input;
using UnityEngine;
using Zenject;

namespace Behaviours
{
    public class TransitionBehaviour : StateMachineBehaviour
    {
        [Inject] private IInputManager _inputManager;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _inputManager.PlayerEnable(false);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            _inputManager.PlayerEnable(true);
        }
    }
}