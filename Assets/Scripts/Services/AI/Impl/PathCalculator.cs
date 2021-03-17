using UnityEngine;
using UnityEngine.AI;

namespace Services.AI.Impl
{
    public class PathCalculator : IPathCalculator
    {
        private readonly NavMeshPath _path;

        public PathCalculator()
        {
            _path = new NavMeshPath();
        }

        public Vector3[] CalculatePath(Vector3 from, Vector3 to)
        {
            NavMesh.CalculatePath(from, to, NavMesh.AllAreas, _path);
            return _path.corners;
        }
    }
}