using System;
using UnityEngine;

namespace ECS.Game.Components
{
    public struct SafeAreaComponent
    {
        public QuadAreaValue Value;
    }

    [Serializable]
    public struct QuadAreaValue
    {
        public Vector3 firstPoint;
        public Vector3 secondPoint;
    }
}