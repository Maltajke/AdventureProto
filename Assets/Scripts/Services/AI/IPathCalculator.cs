using UnityEngine;

namespace Services.AI
{
    public interface IPathCalculator
    {
        Vector3[] CalculatePath(Vector3 from, Vector3 to);
    }
}