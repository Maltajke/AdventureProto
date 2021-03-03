using System;
using UnityEngine;

namespace ECS.Views.Impls.Character.Impls
{
    public class EnemyView : CharacterView
    {
        [SerializeField] private SpriteRenderer _selected;

        private void Awake()
        {
            _selected.gameObject.SetActive(false);
        }

        public void SetSelected(bool value)
        {
            _selected.gameObject.SetActive(value);
        }
    }
}