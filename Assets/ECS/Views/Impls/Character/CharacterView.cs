using Ecs.Views.Linkable.Impl;
using Services.PauseService;
using UnityEngine;

namespace ECS.Views.Impls.Character
{
    public class CharacterView : LinkableView, IPause
    {
        [SerializeField] protected Animator _animator;
        private static readonly int Forward = Animator.StringToHash("Forward");

        public void SetMoveValue(float value)
        {
            _animator.SetFloat(Forward, value, 0.1f, Time.deltaTime);
        }

        public void Pause() => _animator.speed = 0;

        public void UnPause() => _animator.speed = 1;

    }
}