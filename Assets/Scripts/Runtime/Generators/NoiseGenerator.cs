using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class NoiseGenerator
{
    public enum NoiseDrawType { ClassicPerlin, Simplex };

    public enum NoiseEvaluateType { Coherence, Absolute };

    public enum NoiseClampType { InverseLerp, Clamp01, Absolute };

    private static readonly Noise SimplexNoise = new Noise();

    public static float[,] GenerateFalloffMap(int width, int height, float a = 3f, float b = 2.2f)
    {
        float[,] falloffMap = new float[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var i = x / (float)width * 2 - 1;
                var j = y / (float)height * 2 - 1;

                float v = Mathf.Max(Mathf.Abs(i), Mathf.Abs(j));

                falloffMap[x, y] = Mathf.Pow(v, a) / (Mathf.Pow(v, a) + Mathf.Pow(b - b * v, a));
            }
        }

        return falloffMap;
    }

    public static float[,] GenerateSimplexNoiseMap(int width, int height, float strength = 1f, float baseRoughness = 1f, float roughness = 2f, int layers = 3, float persistance = 0.5f)
    {
        float[,] noiseMap = new float[width, height];

        var maxHeight = float.MinValue;
        var minHeight = float.MaxValue;

        for (int y = 0; y < noiseMap.GetLength(1); y++)
        {
            for (int x = 0; x < noiseMap.GetLength(0); x++)
            {
                var sv = 0f;

                for (int i = 0; i < layers; i++)
                {
                    var p = new Vector2(x, y);

                    var v = SimplexNoise.Evaluate(p);

                    sv += (v + 1) * 0.5f;
                    sv += v;
                }

                if (sv > maxHeight) maxHeight = sv;
                else if (sv < minHeight) minHeight = sv;

                noiseMap[x, y] = sv;
            }
        }

        for (int y = 0; y < noiseMap.GetLength(1); y++)
        {
            for (int x = 0; x < noiseMap.GetLength(0); x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minHeight, maxHeight, noiseMap[x, y]);
            }
        }

        return noiseMap;
    }

    public static float[,] GenerateClassicPerlinNoiseMap(int width, int height, float scale, int octaves, float persistance, float lacunarity, int seed, Vector2 offset,
        float falloffValueA = 0f, float falloffValueB = 0f, NoiseEvaluateType evaluateType = NoiseEvaluateType.Coherence, NoiseClampType clampType = NoiseClampType.InverseLerp)
    {
        if (width < 1 || height < 1 || scale < 1 || octaves < 1) return null;

        var noiseMap = new float[width, height];

        var prng = new System.Random(seed);

        var octaveOffset = new Vector2[octaves];

        for (int i = 0; i < octaves; i++)
        {
            var ox = prng.Next(-100000, 100000) + offset.x;
            var oy = prng.Next(-100000, 100000) - offset.y;

            octaveOffset[i] = new Vector2(ox, oy);
        }

        var halfWidth = width / 2f;
        var halfHeight = height / 2f;

        var maxHeight = float.MinValue;
        var minHeight = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var amplitude = 1f;
                var frequency = 1f;
                var noiseValue = 0f;

                for (int i = 0; i < octaves; i++)
                {
                    var sx = (x - halfWidth) / scale * frequency + octaveOffset[i].x;
                    var sy = (y - halfHeight) / scale * frequency + octaveOffset[i].y;

                    var pv = Mathf.PerlinNoise(sx, sy) * 2 - 1;

                    noiseValue += pv * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                switch (evaluateType)
                {
                    case NoiseEvaluateType.Coherence:
                        noiseMap[x, y] = noiseValue;
                        break;
                    case NoiseEvaluateType.Absolute:
                        noiseMap[x, y] = Mathf.Abs(noiseValue);
                        break;
                }

                if (noiseValue > maxHeight) maxHeight = noiseValue;
                else if (noiseValue < minHeight) minHeight = noiseValue;
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                switch (clampType)
                {
                    case NoiseClampType.InverseLerp:
                        noiseMap[x, y] = Mathf.InverseLerp(minHeight, maxHeight, noiseMap[x, y]);
                        break;
                    case NoiseClampType.Clamp01:
                        noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y]);
                        break;
                    case NoiseClampType.Absolute:
                        noiseMap[x, y] = Mathf.Abs(noiseMap[x, y]);
                        break;
                }
            }
        }

        if (falloffValueA != 0 && falloffValueB != 0)
        {
            var falloffMap = GenerateFalloffMap(width, height, falloffValueA, falloffValueB);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - falloffMap[x, y]);
                }
            }
        }

        return noiseMap;
    }
}