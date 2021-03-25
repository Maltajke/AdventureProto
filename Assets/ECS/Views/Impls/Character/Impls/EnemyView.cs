using ECS.Game.Components.Listeners;
using ECS.Game.Components.Listeners.Impl;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Views.Impls.Character.Impls
{
    public class EnemyView : CharacterView
    {
        [SerializeField] private SpriteRenderer _selected;

        private void Awake()
        {
            _selected.gameObject.SetActive(false);
            View(false);
        }

        public override void Link(EcsEntity entity)
        {
            entity.Get<IsAvailableListenerComponent>().Value = View;
        }

        private void View(bool b)
        { 
            gameObject.SetActive(b);
        }
    }
}