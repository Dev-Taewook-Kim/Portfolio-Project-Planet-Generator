using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    readonly static Vector3[] LocalUp = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

    public static Mesh GenerateNoiseCube(int resolution, float radius, Vector3 center = default, bool normalize = true)
    {
        Mesh mesh = new Mesh();

        var vertices = new Vector3[LocalUp.Length * resolution * resolution];

        var triangles = new int[LocalUp.Length * ((resolution - 1) * (resolution - 1) * 2 * 3)];

        var ti = 0;

        for (int i = 0; i < LocalUp.Length; i++)
        {
            var axisA = new Vector3(LocalUp[i].y, LocalUp[i].z, LocalUp[i].x);
            var axisB = Vector3.Cross(LocalUp[i], axisA);

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    var percentOnUnitCube = new Vector2(x, y) / (resolution - 1);
                    var pointOnUnitCube = LocalUp[i] + ((percentOnUnitCube.x - 0.5f) * 2 * axisA) + ((percentOnUnitCube.y - 0.5f) * 2 * axisB);
                    var pointOnUnitSphere = pointOnUnitCube.normalized;

                    var v = ((i * resolution * resolution) + x) + y * resolution;

                    vertices[v] = normalize == true ? pointOnUnitSphere : pointOnUnitCube;

                    if (x != resolution - 1 && y != resolution - 1)
                    {
                        triangles[ti] = v;
                        triangles[ti + 1] = v + resolution + 1;
                        triangles[ti + 2] = v + resolution;

                        triangles[ti + 3] = v;
                        triangles[ti + 4] = v + 1;
                        triangles[ti + 5] = v + resolution + 1;

                        ti += 6;
                    }
                }
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return default;
    }
}