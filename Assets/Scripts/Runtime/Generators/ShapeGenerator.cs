using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShapeGenerator
{
    static Vector3 LinearInterpolate(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }

    static Vector3 QuadraticInterpolate(Vector2 a, Vector2 b, Vector2 c, float t)
    {
        var p0 = LinearInterpolate(a, b, t);
        var p1 = LinearInterpolate(b, c, t);

        return LinearInterpolate(p0, p1, t);
    }

    static Vector3 CubicInterpolate(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
    {
        var p0 = QuadraticInterpolate(a, b, c, t);
        var p1 = QuadraticInterpolate(b, c, d, t);

        return LinearInterpolate(p0, p1, t);
    }

    public static Vector3[] GeneratePointShape(int vertexCount, int radius, float vertexScale, Vector3 origin = default, bool loop = true)
    {
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < vertexCount; i++)
        {
            var x0 = Mathf.Cos(Mathf.Deg2Rad * (i * (360f / vertexCount))) * radius * vertexScale + origin.x;
            var y0 = Mathf.Sin(Mathf.Deg2Rad * (i * (360f / vertexCount))) * radius * vertexScale + origin.y;
            var z0 = 0 + origin.z;

            var p0 = new Vector3(x0, y0, z0);

            points.Add(p0);
        }

        if (loop == true) points.Add(points[0]);

        return points.ToArray();
    }
}