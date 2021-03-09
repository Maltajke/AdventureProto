using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Serialization;

namespace ECS.Views.Impls.Character.Impls
{
    public class MainPlayerView : CharacterView
    {
        [SerializeField] private GameObject bowMeshBack;
        [SerializeField] private GameObject bowMeshArm;
        
        private static readonly int Aggressive = Animator.StringToHash("Aggressive");
        private static readonly int Dive = Animator.StringToHash("Dive");
        private static readonly int Shooting = Animator.StringToHash("Shooting");

        private void EnableMesh(int value)
        {
            bowMeshBack.SetActive(value == 1);
            bowMeshArm.SetActive(value == 0);
        }

        public void SetAggressState(bool value) => _animator.SetBool(Aggressive, value);
        public void SetDive(bool value) => _animator.SetBool(Dive, value);
        public void SetShooting(bool value) => _animator.SetBool(Shooting, value);
    }
}