using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPreviewer : MonoBehaviour
{
    public enum DrawMode { Texture, Mesh };

    [Header("Texture Setting")]
    [Range(2, 128)]
    public int resolution = 64;

    public FilterMode filterMode = FilterMode.Bilinear;

    public TextureWrapMode textureWrapMode = TextureWrapMode.Repeat;


    [Header("Terrain Setting")]

    public NoiseGenerator.NoiseDrawType terrainNoiseDrawType;

    public NoiseGenerator.NoiseEvaluateType terrainNoiseEvaluateType;

    public NoiseGenerator.NoiseClampType terrainNoiseClampType;

    [Range(-32f, 32f)]
    public float terrainFalloffValueA = 3f;

    [Range(0f, 64f)]
    public float terrainFalloffValueB = 2.2f;

    public NoiseSetting terrainNoiseSetting;

    public ColorSetting terrainColorSetting;


    [Header("Cloud Setting")]

    public NoiseGenerator.NoiseDrawType cloudNoiseDrawType;

    public NoiseGenerator.NoiseEvaluateType cloudNoiseEvaluateType;

    public NoiseGenerator.NoiseClampType cloudNoiseClampType;

    [Range(-32f, 32f)]
    public float cloudFalloffValueA = 3f;

    [Range(0f, 64f)]
    public float cloudFalloffValueB = 2.2f;

    [Range(0f, 1f)]
    public float cloudCutoffValue = 0.5f;

    public Color cloudStartColor = Color.clear;

    public Color cloudEndColor = Color.white;

    public NoiseSetting cloudNoiseSetting;

    [HideInInspector]
    public GameObject planetObject;

    [HideInInspector]
    public GameObject cloudObject;


    [Header("Glodbal Setting")]
    public DrawMode drawMode = DrawMode.Texture;

    public bool disableOnPlayMode = false;

    public void InitObject()
    {
        if (planetObject == null)
        {
            planetObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planetObject.name = "PlanetObject";
            planetObject.transform.SetParent(transform);
            planetObject.transform.localPosition = Vector3.zero;
            planetObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

            planetObject.GetComponent<Renderer>().sharedMaterial = new Material(Shader.Find("Unlit/Texture"))
            {
                mainTexture = new Texture2D(1, 1)
            };

            planetObject.AddComponent<ObjectTextureScroller>();
        }

        if (cloudObject == null)
        {
            cloudObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            cloudObject.name = "PlanetCloud";
            cloudObject.transform.SetParent(transform);
            cloudObject.transform.localPosition = Vector3.zero;
            cloudObject.transform.localScale = new Vector3(2.7f, 2.7f, 2.7f);

            cloudObject.GetComponent<Renderer>().sharedMaterial = new Material(Shader.Find("Unlit/Transparent Cutout"))
            {
                mainTexture = new Texture2D(1, 1)
            };

            cloudObject.AddComponent<ObjectTextureScroller>();
        }

        UpdateTexture();
    }

    public void UpdateTexture()
    {
        if (terrainNoiseSetting != null && terrainColorSetting != null)
        {
            float[,] noiseMap = null;

            switch (terrainNoiseDrawType)
            {
                case NoiseGenerator.NoiseDrawType.ClassicPerlin:
                    noiseMap = NoiseGenerator.GenerateClassicPerlinNoiseMap(resolution, resolution, terrainNoiseSetting.scale, terrainNoiseSetting.octaves, terrainNoiseSetting.persistance, terrainNoiseSetting.lacunarity,
                                terrainNoiseSetting.seed, terrainNoiseSetting.offset, terrainFalloffValueA, terrainFalloffValueB, terrainNoiseEvaluateType, terrainNoiseClampType);
                    break;
                case NoiseGenerator.NoiseDrawType.Simplex:
                    noiseMap = NoiseGenerator.GenerateSimplexNoiseMap(resolution, resolution);
                    break;
            }

            var mainTex = TextureGenerator.GenerateColorMap(noiseMap, terrainColorSetting.gradient, filterMode, textureWrapMode);

            planetObject.GetComponent<Renderer>().sharedMaterial.mainTexture = mainTex;
        }

        if (cloudNoiseSetting != null)
        {
            float[,] noiseMap = null;

            switch (cloudNoiseDrawType)
            {
                case NoiseGenerator.NoiseDrawType.ClassicPerlin:
                    noiseMap = NoiseGenerator.GenerateClassicPerlinNoiseMap(resolution, resolution, cloudNoiseSetting.scale, cloudNoiseSetting.octaves, cloudNoiseSetting.persistance, cloudNoiseSetting.lacunarity,
                                cloudNoiseSetting.seed, cloudNoiseSetting.offset, cloudFalloffValueA, cloudFalloffValueB, cloudNoiseEvaluateType, cloudNoiseClampType);
                    break;
                case NoiseGenerator.NoiseDrawType.Simplex:
                    noiseMap = NoiseGenerator.GenerateSimplexNoiseMap(resolution, resolution);
                    break;
            }

            var mainTex = TextureGenerator.GenerateColorMapCutout(noiseMap, cloudStartColor, cloudEndColor, cloudCutoffValue, filterMode, textureWrapMode);

            cloudObject.GetComponent<Renderer>().sharedMaterial.mainTexture = mainTex;
            cloudObject.GetComponent<Renderer>().sharedMaterial.SetFloat(Shader.PropertyToID("_Cutoff"), cloudCutoffValue);
        }
    }
}
