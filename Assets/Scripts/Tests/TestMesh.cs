using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
    public class TestMesh : MonoBehaviour
    {
        [SerializeField] private Mesh _mesh;
        private struct Triangle
        {
            private readonly Vector3 vert1;
            private readonly Vector3 vert2;
            private readonly Vector3 vert3;

            public Triangle(Vector3 vert1, Vector3 vert2, Vector3 vert3)
            {
                this.vert1 = vert1;
                this.vert2 = vert2;
                this.vert3 = vert3;
            }

            public void Draw()
            {
                Gizmos.DrawLine(vert1, vert2);
                Gizmos.DrawLine(vert2, vert3);
                Gizmos.DrawLine(vert3, vert1);
            }
        }
        
        private readonly List<Triangle> _triangles = new List<Triangle>();
        
        private void Start()
        {
            for (var index = 0; index < _mesh.triangles.Length; index+=3)
            {
                var st1 = _mesh.triangles[index];
                var st2 = _mesh.triangles[index+1];
                var st3 = _mesh.triangles[index+2];

                var vert1 = transform.TransformPoint(_mesh.vertices[st1]);
                var vert2 = transform.TransformPoint(_mesh.vertices[st2]);
                var vert3 = transform.TransformPoint(_mesh.vertices[st3]);
                
                _triangles.Add(new Triangle(vert1,vert2,vert3));
            }
        }

        private void OnDrawGizmos()
        {
            var color = Gizmos.color;
            Gizmos.color = Color.green;
            foreach (var t in _triangles)
            {
                t.Draw();
            }
            Gizmos.color = color;
        }
    }
}