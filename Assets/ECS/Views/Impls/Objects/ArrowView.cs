using System.Collections.Generic;
using ECS.Game.Components.Listeners;
using ECS.Game.Components.Listeners.Impl;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using Services.PauseService;
using UnityEngine;

namespace ECS.Views.Impls.Objects
{
    public class ArrowView : LinkableView, IPause
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private ParticleSystem _trail;
        private readonly List<ParticleSystem> _trailChildren = new List<ParticleSystem>();
        public override void Link(EcsEntity entity)
        {
            base.Link(entity);
            foreach(var child in _trail.GetComponentsInChildren<ParticleSystem>())
                _trailChildren.Add(child);
            entity.Get<IsAvailableListenerComponent>().Value = SetEnable;
            SetEnable(false);
        }

        private void SetEnable(bool value)
        {
            _renderer.enabled = value;
            var emission = _trail.emission;
            emission.enabled = value;
            foreach (var c in _trailChildren)
            {
                var emissionC = c.emission;
                emissionC.enabled = value;
            }
        }

        public void Pause()
        {
            _trail.Pause();
            foreach (var c in _trailChildren)
                c.Pause();
        }

        public void UnPause()
        {
            _trail.Play();
            foreach (var c in _trailChildren)
                c.Play();
        }
    }
}