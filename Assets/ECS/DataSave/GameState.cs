using System.Collections.Generic;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using PdUtils;
using UnityEngine;

namespace ECS.DataSave
{
    public class GameState
    {
        public List<SaveState> States;
        public string SceneKey;
    }

    public class SaveState
    {
        public bool IsAi { get; set; }
        public bool IsArrow { get; set; }
        public bool IsCamera { get; set; }
        public bool IsEnemy { get; set; }
        public bool InSafeArea { get; set; }
        public bool IsInteract { get; set; }
        public bool IsShooting { get; set; }
        public bool IsLevel { get; set; }
        public bool IsNpc { get; set; }
        public bool IsPlayer { get; set; }
        
        public int? Damage { get; set; }
        public float? DistanceToPlayer { get; set; }
        public Uid? Owner { get; set; }
        public Vector3? Position { get; set; }
        public string Prefab { get; set; }
        public Quaternion? Rotation { get; set; }
        public Uid? Target { get; set; }
        public Vector3? TargetPosition { get; set; }
        public QuadAreaValue? QuadArea { get; set; }
        public Uid? Uid { get; set; }

        public void WriteState(EcsEntity entity)
        {
            IsAi = entity.Has<AiComponent>();
            IsArrow = entity.Has<ArrowComponent>();
            IsCamera = entity.Has<CameraComponent>();
            IsEnemy = entity.Has<EnemyComponent>();
            InSafeArea = entity.Has<SafeAreaComponent>();
            IsInteract = entity.Has<InteractComponent>();
            IsShooting = entity.Has<IsShootingComponent>();
            IsLevel = entity.Has<LevelComponent>();
            IsNpc = entity.Has<NpcComponent>();
            IsPlayer = entity.Has<PlayerComponent>();

            if (entity.Has<DamageComponent>())
                Damage = entity.Get<DamageComponent>().Value;
            if (entity.Has<DistanceToPlayerComponent>())
                DistanceToPlayer = entity.Get<DistanceToPlayerComponent>().Value;
            if (entity.Has<OwnerComponent>())
                Owner = entity.Get<OwnerComponent>().Value;
            if (entity.Has<PositionComponent>())
                Position = entity.Get<PositionComponent>().Value;
            if (entity.Has<PrefabComponent>())
                Prefab = entity.Get<PrefabComponent>().Value;
            if (entity.Has<RotationComponent>())
                Rotation = entity.Get<RotationComponent>().Value;
            if (entity.Has<TargetComponent>())
                Target = entity.Get<TargetComponent>().Value;
            if (entity.Has<TargetPositionComponent>())
                TargetPosition = entity.Get<TargetPositionComponent>().Value;
            if (entity.Has<SafeAreaComponent>())
                QuadArea = entity.Get<SafeAreaComponent>().Value;
            if (entity.Has<UIdComponent>())
                Uid = entity.Get<UIdComponent>().Value;
        }

        public void ReadState(EcsEntity entity)
        {
            if(IsAi) entity.Get<AiComponent>();
            if(IsArrow) entity.Get<ArrowComponent>();
            if(IsCamera) entity.Get<CameraComponent>();
            if(IsEnemy) entity.Get<EnemyComponent>();
            if(InSafeArea) entity.Get<SafeAreaComponent>();
            if(IsInteract) entity.Get<InteractComponent>();
            if(IsShooting) entity.Get<IsShootingComponent>();
            if(IsLevel) entity.Get<LevelComponent>();
            if(IsNpc) entity.Get<NpcComponent>();
            if(IsPlayer) entity.Get<PlayerComponent>();
          
            if (Damage.HasValue)
                entity.Get<DamageComponent>().Value = Damage.Value;
            if (DistanceToPlayer.HasValue)
                entity.Get<DistanceToPlayerComponent>().Value = DistanceToPlayer.Value;
            if (Owner.HasValue)
                entity.Get<OwnerComponent>().Value = Owner.Value;
            if (Position.HasValue)
                entity.Get<PositionComponent>().Value = Position.Value;
            if (Rotation.HasValue)
                entity.Get<RotationComponent>().Value = Rotation.Value;
            if (Target.HasValue)
                entity.Get<TargetComponent>().Value = Target.Value;
            if (TargetPosition.HasValue)
                entity.Get<TargetPositionComponent>().Value = TargetPosition.Value;
            if (QuadArea.HasValue)
                entity.Get<SafeAreaComponent>().Value = QuadArea.Value;
            if (Uid.HasValue)
                entity.Get<UIdComponent>().Value = Uid.Value;
            
            if (Prefab != null)
            {
                entity.Get<PrefabComponent>().Value = Prefab;
                entity.Get<EventAddComponent<PrefabComponent>>();
            }
        }
    }
}