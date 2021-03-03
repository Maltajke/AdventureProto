using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace ECS.Views.Impls
{
    [RequireComponent(typeof(Camera))]
    public class CameraView : LinkableView
    {
        public Camera Camera { get; private set; }
        
        private void Awake()
        {
            Camera = GetComponent<Camera>();
        }
    }
}