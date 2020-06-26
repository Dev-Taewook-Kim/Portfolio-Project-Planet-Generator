using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    delegate Color Eveluate(float a, float b);

    static Texture2D GenerateTexture2D(int width, int height, Color[] colorMap, FilterMode filterMode, TextureWrapMode textureWrapMode)
    {
        Texture2D mainTex = new Texture2D(width, height)
        {
            name = "mainTex"
        };

        mainTex.SetPixels(colorMap);
        mainTex.filterMode = filterMode;
        mainTex.Apply();

        return mainTex;
    }

    public static Texture2D GenerateColorMap(float[,] noiseMap, Gradient gradient, FilterMode filterMode = FilterMode.Bilinear, TextureWrapMode textureWrapMode = TextureWrapMode.Repeat)
    {
        Color[] colorMap = new Color[noiseMap.GetLength(0) * noiseMap.GetLength(1)];

        for (int y = 0; y < noiseMap.GetLength(1); y++)
        {
            for (int x = 0; x < noiseMap.GetLength(0); x++)
            {
                colorMap[x + y * noiseMap.GetLength(1)] = gradient.Evaluate(noiseMap[x, y]);
            }
        }

        return GenerateTexture2D(noiseMap.GetLength(0), noiseMap.GetLength(1), colorMap, filterMode, textureWrapMode);
    }

    public static Texture2D GenerateColorMap(float[,] noiseMap, Color[] colors, float[] times, FilterMode filterMode = FilterMode.Bilinear, TextureWrapMode textureWrapMode = TextureWrapMode.Repeat)
    {
        Color[] colorMap = new Color[noiseMap.GetLength(0) * noiseMap.GetLength(1)];

        for (int y = 0; y < noiseMap.GetLength(1); y++)
        {
            for (int x = 0; x < noiseMap.GetLength(0); x++)
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    if (noiseMap[x, y] < times[i])
                    {
                        colorMap[x + y * noiseMap.GetLength(1)] = colors[i];
                        break;
                    }
                }

            }
        }

        return GenerateTexture2D(noiseMap.GetLength(0), noiseMap.GetLength(1), colorMap, filterMode, textureWrapMode);
    }

    public static Texture2D GenerateColorMapCutout(float[,] noiseMap, Color startColor, Color endColor, float threshold, FilterMode filterMode = FilterMode.Bilinear, TextureWrapMode textureWrapMode = TextureWrapMode.Repeat)
    {
        Color[] colorMap = new Color[noiseMap.GetLength(0) * noiseMap.GetLength(1)];

        for (int y = 0; y < noiseMap.GetLength(1); y++)
        {
            for (int x = 0; x < noiseMap.GetLength(0); x++)
            {
                if (noiseMap[x, y] < threshold) colorMap[x + y * noiseMap.GetLength(1)] = Color.clear;
                else colorMap[x + y * noiseMap.GetLength(1)] = Color.Lerp(startColor, endColor, Mathf.Clamp(noiseMap[x, y], threshold, 1f));
            }
        }

        return GenerateTexture2D(noiseMap.GetLength(0), noiseMap.GetLength(1), colorMap, filterMode, textureWrapMode);
    }


    public static Texture2D GenerateHeightMap(float[,] noiseMap, Color startColor, Color endColor, FilterMode filterMode = FilterMode.Bilinear, TextureWrapMode textureWrapMode = TextureWrapMode.Repeat)
    {
        Color[] colorMap = new Color[noiseMap.GetLength(0) * noiseMap.GetLength(1)];

        for (int y = 0; y < noiseMap.GetLength(1); y++)
        {
            for (int x = 0; x < noiseMap.GetLength(0); x++)
            {
                colorMap[y * noiseMap.GetLength(0) + x] = Color.Lerp(startColor, endColor, noiseMap[x, y]);
            }
        }

        return GenerateTexture2D(noiseMap.GetLength(0), noiseMap.GetLength(1), colorMap, filterMode, textureWrapMode);
    }
}