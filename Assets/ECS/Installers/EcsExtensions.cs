using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Installers
{
    public static class EcsExtensions
    {
        public static void AddInject<T>(this EcsSystems systems, DiContainer container)
        {
            container.BindInterfacesAndSelfTo<T>().AsSingle();
        }
    }
}