using System;
using System.Runtime.CompilerServices;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using ECS.Views;
using ECS.Views.Impls.Character.Impls;
using Leopotam.Ecs;
using PdUtils;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Utils.Extensions
{
    public static class EcsExtensions
    {
        // private static bool ValidateViewType<T>(this ILinkable linkable)
        // {
        //     if (linkable is T)
        //         return true;
        //     throw new Exception("You must have suitable view component on GameObject");
        // }
        // public static void SetConcreteViewLink(this EcsEntity entity, ref ILinkable linkable)
        // {
        //     if (entity.Has<PlayerComponent>())
        //     {
        //         if (ValidateViewType<MainPlayerView>(linkable))
        //             linkable = (MainPlayerView)linkable;
        //             
        //         
        //     }
        //     else if (entity.Has<EnemyComponent>())
        //     {
        //         if (ValidateViewType<EnemyView>(linkable))
        //             linkable = (EnemyView) linkable;
        //     }
        //     else if (entity.Has<NpcComponent>())
        //     {
        //         if (ValidateViewType<NpcView>(linkable))
        //             linkable = (NpcView) linkable;
        //     }
        // }
        public static void MovePlayerOnNavMesh(Vector3 inputValue, ref Vector3 pos, ref Quaternion rot, float moveSpeed, float rotateSpeed = 1)
        {
            if (!(inputValue.sqrMagnitude >= .01f)) return;
            var newPos = pos + inputValue * Time.deltaTime * moveSpeed;
            var isValid = NavMesh.SamplePosition(newPos, out var hit, .3f, NavMesh.AllAreas);
            if (isValid)
                if ((pos - hit.position).magnitude >= .02f)
                    pos = hit.position;
            var lookDir = new Vector3(inputValue.x, 0, inputValue.z);
            var toRotation = Quaternion.LookRotation(lookDir, Vector3.up);
            rot = Quaternion.RotateTowards(rot, toRotation, 720  * rotateSpeed * Time.deltaTime);
        }
        
        public static EcsEntity GetPlayer(this EcsWorld world)
        {
            var filter = world.GetFilter(typeof(EcsFilter<PlayerComponent, PositionComponent>));
            return filter.GetEntity(0);
        }
        public static EcsEntity GetGameStage(this EcsWorld world)
        {
            var filter = world.GetFilter(typeof(EcsFilter<GameStageComponent>));
            return filter.GetEntity(0);
        }
        
        public static EcsEntity GetEntityWithUid(this EcsWorld world, Uid uid)
        {
            var value = new EcsEntity();
            var filter = world.GetFilter(typeof(EcsFilter<UIdComponent>));
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);
                if (uid.Equals(entity.Get<UIdComponent>().Value))
                    return entity;
            }
            return value;
        }
        
        
        public static void DeclareOneFrameEvents(this EcsSystems systems)
        {
            systems.OneFrame<PrefabComponent>();
            systems.OneFrame<InteractEventComponent>();
            systems.OneFrame<ChangeStageComponent>();
        }
    }
}