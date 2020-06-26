using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PatternGenerator
{
    public static Vector3[] GeneratePhyllotaxis(int loop, float degree, float scale)
    {
        var points = new Vector3[loop];

        for (int i = 0; i < loop; i++)
        {
            var angle = i * (degree * Mathf.Deg2Rad);

            var radius = scale * Mathf.Sqrt(i);

            var x = radius * Mathf.Cos(angle);
            var y = radius * Mathf.Sin(angle);

            points[i] = new Vector3(x, y, 0f);
        }

        return points;
    }
}