using UnityEngine;
using UnityEngine.AI;

public class TestPath : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Transform _point;
    private NavMeshPath _path;
    private Vector3[] _corners;
    private void Awake()
    {
        _path = new NavMeshPath();
        
    }

    private void Update()
    {
        NavMesh.CalculatePath(transform.position, _point.position, NavMesh.AllAreas, _path);
        _corners = _path.corners;
        _line.positionCount = _corners.Length;
        _line.SetPositions(_corners);
        transform.position = Vector3.MoveTowards(transform.position, _corners[1], 5 * Time.deltaTime);
    }
}
