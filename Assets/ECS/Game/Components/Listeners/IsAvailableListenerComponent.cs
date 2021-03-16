using System;

namespace ECS.Game.Components.Listeners
{
    public struct IsAvailableListenerComponent
    {
        public Action<bool> Value;
    }
}