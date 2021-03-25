using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using PdUtils;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Utils.Extensions
{
    public static class EcsExtensions
    {
        public static void MovePlayerOnNavMesh(Vector3 inputValue, ref Vector3 pos, ref Quaternion rot, int areaMask, float moveSpeed, float rotateSpeed = 1)
        {
            if (!(inputValue.sqrMagnitude >= .01f)) return;
            var newPos = pos + inputValue * Time.deltaTime * moveSpeed;
            var isValid = NavMesh.SamplePosition(newPos, out var hit, .3f, areaMask);
            if (isValid)
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
            systems.OneFrame<InteractEventComponent>();
            systems.OneFrame<ChangeStageComponent>();
        }

        public static void CalculateRandomPath(this Vector3[] path, Vector3 start, Vector3 end)
        {
            for (var i = 0; i < path.Length; i++)
            {
                path[i] = Vector3.zero + new Vector3(Mathf.Sin(2f), Mathf.Cos(3f), Mathf.Tan(45)) + end;
                path[i] = Vector3.zero + new Vector3(Mathf.Sin(2f), Mathf.Cos(3f), Mathf.Tan(45)) + end;
                path[i] = Vector3.zero + new Vector3(Mathf.Sin(2f), Mathf.Cos(3f), Mathf.Tan(45)) + end;
                path[i] = Vector3.zero + new Vector3(Mathf.Sin(2f), Mathf.Cos(3f), Mathf.Tan(45)) + end;
                path[i] = Vector3.zero + new Vector3(Mathf.Sin(2f), Mathf.Cos(3f), Mathf.Tan(45)) + end;
            }
        }
    }
}