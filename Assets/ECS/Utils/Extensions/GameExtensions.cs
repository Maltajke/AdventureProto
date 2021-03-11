using DataBase.Game;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Game.Utils.MonoBehUtils;
using Leopotam.Ecs;
using PdUtils;
using Services.Uid;
using UnityEngine;

namespace ECS.Utils.Extensions
{
    public static class GameExtensions
    {
        public static EcsEntity CreatePlayer(this EcsWorld world, Vector3 position)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<PlayerComponent>();
            entity.Get<PositionComponent>().Value = position;
            entity.Get<RotationComponent>().Value = Quaternion.identity;
            entity.Get<PrefabComponent>().Value = "MainPlayer";
            return entity;
        }
        
        public static EcsEntity CreateCamera(this EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<PositionComponent>();
            entity.Get<RotationComponent>().Value = Quaternion.Euler(new Vector3(47,0,0));
            entity.Get<CameraComponent>();
            entity.Get<PrefabComponent>().Value = "MainCamera";
            return entity;
        }

        public static EcsEntity CreateEnemy(this EcsWorld world, Vector3 position)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<EnemyComponent>();
            entity.Get<DistanceToPlayerComponent>();
            entity.Get<PositionComponent>().Value = position;
            entity.Get<RotationComponent>().Value = Quaternion.identity;
            entity.Get<PrefabComponent>().Value = "Enemy";
            return entity;
        }
        
        public static EcsEntity CreateArrow(this EcsWorld world, Vector3 position)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<ArrowComponent>();
            entity.Get<PositionComponent>().Value = position;
            entity.Get<RotationComponent>().Value = Quaternion.identity;
            entity.Get<PrefabComponent>().Value = "Arrow";
            return entity;
        }
        
        public static EcsEntity CreateNPC(this EcsWorld world, Vector3 position, Quaternion rotation)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<NpcComponent>();
            entity.Get<DistanceToPlayerComponent>();
            entity.Get<PositionComponent>().Value = position;
            entity.Get<RotationComponent>().Value = rotation;
            entity.Get<PrefabComponent>().Value = "NPC";
            return entity;
        }
        
        public static EcsEntity CreateLevel(this EcsWorld world, QuadArea quadArea)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<LevelComponent>();
            ref var area = ref entity.Get<SafeAreaComponent>();
            area.firstPoint = quadArea.point1.position;
            area.secondPoint = quadArea.point2.position;
            return entity;
        }
        
        public static EcsEntity CreateGameStage(this EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<GameStageComponent>().Value = EGameStage.Play;
            return entity;
        }
    }
}