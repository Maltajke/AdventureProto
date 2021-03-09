using ECS.Game.Systems;
using ECS.Game.Systems.Character;
using ECS.Game.Systems.Character.Dive;
using ECS.Game.Systems.Linked;
using ECS.Game.Systems.Linked.Character.Shooting;
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
            Container.BindInterfacesAndSelfTo<GameStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GamePauseSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameInitializeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InstantiateSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterStartDiveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterEndDiveSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterMoveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterDiveSystem>().AsSingle();
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
            Container.BindInterfacesAndSelfTo<CharacterSetMoveViewSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CharacterSetDiveViewSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterSetShootingViewSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterShootingStartSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CharacterShootingEndSystem>().AsSingle();
        }
    }
}