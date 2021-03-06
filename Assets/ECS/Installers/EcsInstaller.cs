using ECS.Game.Systems;
using ECS.Game.Systems.Character;
using ECS.Game.Systems.Linked;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Installers
{
    public class EcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EcsWorld>().AsSingle().NonLazy();
            BindSystems();
            Container.BindInterfacesTo<EcsMainBootstrap>().AsSingle();
        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<GameInitializeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InstantiateSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CharacterMoveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraMoveSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CalculateDistanceSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<NpcMarkerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterSafeMarkerSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterSetAggressiveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterUnsetAggressiveSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<NpcSetInteractViewSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<NpcUnsetInteractViewSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<NpcInteractSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<PositionRotationTranslateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SetCharacterViewSystem>().AsSingle();
        }
    }
}