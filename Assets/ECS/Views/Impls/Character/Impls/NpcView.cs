using UnityEngine;

namespace ECS.Views.Impls.Character.Impls
{
    public class NpcView : CharacterView
    {
        [SerializeField] private GameObject interactMarker;

        private void Awake() => interactMarker.SetActive(false);

        public void SetEnableInteract(bool value) => interactMarker.SetActive(value);
    }
}