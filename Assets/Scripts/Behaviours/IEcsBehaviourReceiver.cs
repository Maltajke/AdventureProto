using Leopotam.Ecs;

namespace Behaviours
{
    public interface IEcsBehaviourReceiver
    {
        EcsEntity Entity { set; }
    }
}