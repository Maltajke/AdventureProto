using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Utils.Extensions
{
    public static class EcsExtensions
    {

        public static void MovePlayerOnNavMesh(Vector3 inputValue, ref Vector3 pos, ref Quaternion rot, float moveSpeed, float rotateSpeed = 1)
        {
            if (inputValue.sqrMagnitude >= .01f)
            {
                var newPos = pos + inputValue * Time.deltaTime * moveSpeed;
                var isValid = NavMesh.SamplePosition(newPos, out var hit, .3f, NavMesh.AllAreas);
                if (isValid)
                {
                    if ((pos - hit.position).magnitude >= .02f)
                        pos = hit.position;
                }
                    
                var lookDir = new Vector3(inputValue.x, 0, inputValue.z);
                var toRotation = Quaternion.LookRotation(lookDir, Vector3.up);
                rot = Quaternion.RotateTowards(rot, toRotation, 720  * rotateSpeed * Time.deltaTime);
            }
        }
        
        public static EcsEntity GetPlayer(this EcsWorld world)
        {
            var value = new EcsEntity();
            var filter = world.GetFilter(typeof(EcsFilter<PlayerComponent, PositionComponent>));
            foreach(var i in filter)
                value = filter.GetEntity(i);
            return value;
        }
        public static EcsEntity GetGameStage(this EcsWorld world)
        {
            var value = new EcsEntity();
            var filter = world.GetFilter(typeof(EcsFilter<GameStageComponent>));
            foreach(var i in filter)
                value = filter.GetEntity(i);
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