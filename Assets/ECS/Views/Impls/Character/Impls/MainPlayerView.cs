using UnityEngine;
using UnityEngine.Serialization;

namespace ECS.Views.Impls.Character.Impls
{
    public class MainPlayerView : CharacterView
    {
        [SerializeField] private GameObject bowMeshBack;
        [SerializeField] private GameObject bowMeshArm;
        private static readonly int Aggressive = Animator.StringToHash("Aggressive");

        private void EnableMesh(int value)
        {
            bowMeshBack.SetActive(value == 1);
            bowMeshArm.SetActive(value == 0);
        }

        public void SetAggressState(bool value) => _animator.SetBool(Aggressive, value);

    }
}