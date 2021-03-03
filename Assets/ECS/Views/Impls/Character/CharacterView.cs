using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace ECS.Views.Impls.Character
{
    public class CharacterView : LinkableView
    {
        [SerializeField] private Animator _animator;
        private static readonly int Forward = Animator.StringToHash("Forward");

        public void SetMoveValue(float value)
        {
            _animator.SetFloat(Forward, value, 0.1f, Time.deltaTime);
        }
    }
}