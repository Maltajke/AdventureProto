using ECS.Core.Utils;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Installers
{
    public class EcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSystems();
            Container.BindInterfacesTo<EcsMainBootstrap>().AsSingle();
        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<TestSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TestSystem2>().AsSingle();
        }
    }
}