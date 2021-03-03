using System;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using Leopotam.Ecs;

namespace ECS.Utils.Extensions
{
    public static class EcsExtensions
    {
        public static void DeclareOneFrameEvents(this EcsSystems systems)
        {
            systems.OneFrame<PrefabComponent>();
        }
    }
}