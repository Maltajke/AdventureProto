using ECS.Game.Components.Flags;
using Ecs.Views.Linkable.Impl;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Views.Impls
{
    [RequireComponent(typeof(Camera))]
    public class CameraView : LinkableView
    {
        public override void Link(EcsEntity entity)
        {
            entity.Get<CameraComponent>().Camera = GetComponent<Camera>();
        }
    }
}