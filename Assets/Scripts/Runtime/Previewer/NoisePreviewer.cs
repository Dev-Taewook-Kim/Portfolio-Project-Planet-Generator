using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisePreviewer : MonoBehaviour
{
    public enum DrawMode { Value, Preset }

    public enum ColorMode { Height, Color, Preset }

    [Header("Texture Setting")]
    [Range(2, 256)]
    public int resolution = 64;

    public FilterMode filterMode = FilterMode.Bilinear;

    public TextureWrapMode textureWrapMode = TextureWrapMode.Repeat;


    [Header("Noise Setting")]
    public NoiseGenerator.NoiseDrawType noiseDrawType = NoiseGenerator.NoiseDrawType.ClassicPerlin;

    public NoiseGenerator.NoiseEvaluateType noiseEvaluateType = NoiseGenerator.NoiseEvaluateType.Coherence;

    public NoiseGenerator.NoiseClampType noiseClampType = NoiseGenerator.NoiseClampType.InverseLerp;

    public DrawMode drawMode = DrawMode.Value;

    [Range(1, 100)]
    public int scale = 25;

    [Range(1, 5)]
    public int octaves = 3;

    [Range(0f, 1f)]
    public float persistance = 0.5f;

    [Range(1.5f, 3.5f)]
    public float lacunarity = 2.5f;

    public int seed = 197328465;

    public Vector2 offset;

    public NoiseSetting noisePreset;


    [Header("Falloff Setting")]
    public float falloffValueA = 3f;

    public float falloffValueB = 2.2f;

    [Header("Color Setting")]
    public ColorMode colorMode = ColorMode.Height;

    public Gradient colorGradient;

    public ColorSetting colorPreset;

    [HideInInspector]
    public GameObject viewerObject;

    [Header("Glodbal Setting")]
    public bool disableOnPlayMode = false;

    private void OnEnable()
    {
        viewerObject.SetActive(false);
    }

    private void OnDisable()
    {
        viewerObject.SetActive(true);
    }

    public void InitObject()
    {
        if (viewerObject == null)
        {
            viewerObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
            viewerObject.name = "viewerObject";
            viewerObject.transform.SetParent(transform);
            viewerObject.transform.localPosition = Vector3.zero;
            viewerObject.transform.localScale = new Vector3(5f, 5f, 5f);

            viewerObject.GetComponent<Renderer>().sharedMaterial = new Material(Shader.Find("Unlit/Texture"))
            {
                mainTexture = new Texture2D(1, 1)
            };
        }

        UpdateTexture();
    }

    public void UpdateTexture()
    {
        float[,] noiseMap = null;

        switch (noiseDrawType)
        {
            case NoiseGenerator.NoiseDrawType.ClassicPerlin:
                switch (drawMode)
                {
                    case DrawMode.Value:
                        noiseMap = NoiseGenerator.GenerateClassicPerlinNoiseMap(resolution, resolution, scale, octaves, persistance, lacunarity, seed, offset,
                            falloffValueA, falloffValueB, noiseEvaluateType, noiseClampType);
                        break;
                    case DrawMode.Preset:
                        noiseMap = NoiseGenerator.GenerateClassicPerlinNoiseMap(resolution, resolution, noisePreset.scale, noisePreset.octaves, noisePreset.persistance, noisePreset.lacunarity,
                            noisePreset.seed, noisePreset.offset, falloffValueA, falloffValueB, noiseEvaluateType, noiseClampType);
                        break;
                }
                break;
            case NoiseGenerator.NoiseDrawType.Simplex:
                switch (drawMode)
                {
                    case DrawMode.Value:
                        noiseMap = NoiseGenerator.GenerateSimplexNoiseMap(resolution, resolution);
                        break;
                    case DrawMode.Preset:
                        noiseMap = NoiseGenerator.GenerateSimplexNoiseMap(resolution, resolution);
                        break;
                }
                break;
        }

        Texture2D mainTex = null;

        if (colorMode == ColorMode.Preset) mainTex = TextureGenerator.GenerateColorMap(noiseMap, colorPreset.gradient, filterMode, textureWrapMode);
        else if (colorMode == ColorMode.Color) mainTex = TextureGenerator.GenerateColorMap(noiseMap, colorGradient, filterMode, textureWrapMode);
        else mainTex = TextureGenerator.GenerateHeightMap(noiseMap, Color.black, Color.white, filterMode, textureWrapMode);

        viewerObject.GetComponent<Renderer>().sharedMaterial.mainTexture = mainTex;
    }
}