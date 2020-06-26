using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Noise Setting", menuName = "Main Project Assets/Noise Setting")]
public class NoiseSetting : ScriptableObject
{
    private static readonly float FixedScale = 25f;

    private static readonly int MinOctaves = 1;
    private static readonly int MaxOctaves = 5;

    private static readonly float MinPersistance = 0f;
    private static readonly float MaxPersistance = 1f;

    private static readonly float MinLacunarity = 1.5f;
    private static readonly float MaxLacunarity = 3.5f;

    [System.Serializable]
    public struct Data
    {
        public float scale;

        public int octaves;

        public float persistance;

        public float lacunarity;

        public int seed;

        public Vector2 offset;

        public Data(float _scale, int _octaves, float _persistance, float _lacunarity, int _seed, Vector2 _offset)
        {
            scale = _scale;

            octaves = _octaves;

            persistance = _persistance;

            lacunarity = _lacunarity;

            seed = _seed;

            offset = _offset;
        }
    }

    [Range(25f, 100f)]
    public float scale = 25f;

    [Range(1, 5)]
    public int octaves = 3;

    [Range(0f, 1f)]
    public float persistance = 0.5f;

    [Range(1.5f, 3.5f)]
    public float lacunarity = 2f;

    public int seed = 41309102;

    public Vector2 offset;

    public void SetDefault()
    {
        scale = 25f;

        octaves = 3;

        persistance = 0.5f;

        lacunarity = 2f;

        seed = 41309102;

        offset = Vector2.zero;
    }

    public void GenerateRandom()
    {
        scale = FixedScale;

        octaves = Random.Range(MinOctaves, MaxOctaves + 1);

        persistance = Random.Range(MinPersistance, MaxPersistance);

        lacunarity = Random.Range(MinLacunarity, MaxLacunarity);

        seed = Random.Range(int.MinValue, int.MaxValue);
    }
}