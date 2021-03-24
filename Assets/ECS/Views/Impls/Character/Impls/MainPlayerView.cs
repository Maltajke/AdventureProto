using ECS.Game.Components;
using ECS.Game.Components.Events;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Views.Impls.Character.Impls
{
    public class MainPlayerView : CharacterView
    {
        [Inject] private readonly EcsWorld _world;
        
        [SerializeField] private GameObject bowMeshBack;
        [SerializeField] private GameObject bowMeshArm;
        [SerializeField] private GameObject arrowMesh;
        
        private static readonly int Aggressive = Animator.StringToHash("Aggressive");
        private static readonly int Dive = Animator.StringToHash("Dive");
        private static readonly int Shooting = Animator.StringToHash("Shooting");

        private void Awake()
        {
            arrowMesh.SetActive(false);
        }

        private void ShotSignal()
        {
            var shotEvent = _world.NewEntity();
            shotEvent.Get<ShotEventComponent>();
            shotEvent.Get<PositionComponent>().Value = arrowMesh.transform.position;
            shotEvent.Get<RotationComponent>().Value = arrowMesh.transform.rotation;
            shotEvent.Get<OwnerComponent>().Value = _entity.Get<UIdComponent>().Value;
        }

        public void SetAggressState(bool value) => _animator.SetBool(Aggressive, value);
        public void SetDive(bool value) => _animator.SetBool(Dive, value);
        public void SetShooting(bool value) => _animator.SetBool(Shooting, value);

        #region AnimatorEvents
        private void EnableArrowMesh(int value)
        {
            arrowMesh.SetActive(value == 1);
            if (value != 0) return;
            ShotSignal();
        }
        private void EnableBowMesh(int value)
        {
            bowMeshBack.SetActive(value == 1);
            bowMeshArm.SetActive(value == 0);
        }
        #endregion
    }
}