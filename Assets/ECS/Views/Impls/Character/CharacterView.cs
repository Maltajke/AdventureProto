using Behaviours;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using Services.PauseService;
using UnityEngine;

namespace ECS.Views.Impls.Character
{
    public class CharacterView : LinkableView, IPause
    {
        [SerializeField] protected Animator _animator;
        private static readonly int Forward = Animator.StringToHash("Forward");

        public override void Link(EcsEntity entity)
        {
            base.Link(entity);
            InjectBehaviourData(entity);
        }

        private void InjectBehaviourData(EcsEntity entity)
        {
            var behaviours = _animator.GetBehaviours<StateMachineBehaviour>();
            foreach (var behaviour in behaviours)
            {
                if (!(behaviour is IEcsBehaviourReceiver)) continue;
                var iReceiver = (IEcsBehaviourReceiver) behaviour;
                iReceiver.Entity = entity;
            }
        }
        
        public void SetMoveValue(float value) => _animator.SetFloat(Forward, value, 0.1f, Time.deltaTime);
        public void Pause() => _animator.speed = 0;
        public void UnPause() => _animator.speed = 1;
    }
}