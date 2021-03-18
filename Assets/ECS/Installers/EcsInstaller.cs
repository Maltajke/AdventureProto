using ECS.Game.Systems;
using ECS.Game.Systems.AI;
using ECS.Game.Systems.Arrow;
using ECS.Game.Systems.Character;
using ECS.Game.Systems.Character.Dive;
using ECS.Game.Systems.Linked;
using ECS.Game.Systems.Linked.Character;
using ECS.Game.Systems.Linked.Character.Shooting;
using ECS.Game.Systems.Linked.Npc;
using ECS.Game.Systems.Npc;
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
            Container.BindInterfacesAndSelfTo<IsAvailableSetViewSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GamePauseSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameInitializeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InstantiateSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<TargetPositionSystem>().AsSingle();

            //Container.BindInterfacesAndSelfTo<CalculatePathSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CalculatePathSystemThread>().AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterStartDiveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterEndDiveSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterLookAtSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterMoveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterDiveSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CameraMoveSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CalculateDistanceSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<NpcMarkerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterSafeMarkerSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CharacterSetAggressiveViewSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<NpcSetInteractViewSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<NpcInteractSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CharacterSetMoveViewSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CharacterSetDiveViewSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterSetShootingViewSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterShootingStartSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterShootingEndSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CharacterSetTargetSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<ArrowShotSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ArrowMoveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ArrowDestroySystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<PositionRotationTranslateSystem>().AsSingle();
        }
    }
}