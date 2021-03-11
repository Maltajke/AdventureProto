﻿using System;
using ECS.Game.Components.Events;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Serialization;
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

        private void EnableArrowMesh(int value)
        {
            arrowMesh.SetActive(value == 1);
            if (value != 0) return;
            _world.NewEntity().Get<ShotEventComponent>().startPosition = arrowMesh.transform.position;

        }
        private void EnableBowMesh(int value)
        {
            bowMeshBack.SetActive(value == 1);
            bowMeshArm.SetActive(value == 0);
        }

        public void SetAggressState(bool value) => _animator.SetBool(Aggressive, value);
        public void SetDive(bool value) => _animator.SetBool(Dive, value);
        public void SetShooting(bool value) => _animator.SetBool(Shooting, value);
    }
}