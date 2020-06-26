using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color Setting", menuName = "Main Project Assets/Color Setting")]
public class ColorSetting : ScriptableObject
{
    [System.Serializable]
    public struct Data
    {
        public Color[] colors;
        public float[] times;

        public Data(Color[] _colors, float[] _times)
        {
            colors = new Color[_colors.Length];
            times = new float[_times.Length];

            for (int c = 0; c < _colors.Length; c++)
            {
                colors[c] = _colors[c];
            }

            for (int t = 0; t < times.Length; t++)
            {
                times[t] = _times[t];
            }
        }
    }

    public Gradient gradient;

    public void SetDefault()
    {
        GradientColorKey[] colorKeys = new GradientColorKey[] { new GradientColorKey(Color.white, 0f), new GradientColorKey(Color.white, 1f) };
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) };

        gradient.SetKeys(colorKeys, alphaKeys);
    }

    public void GenerateRandom()
    {
        GradientColorKey[] colorKeys = new GradientColorKey[Random.Range(5, 8 + 1)];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) };

        Debug.Log(colorKeys.Length);

        for (int i = 0; i < colorKeys.Length; i++)
        {
            colorKeys[i].time = i == 0 ? 0f : Random.Range((float)(i - 1) / (colorKeys.Length - 1), (float)i / (colorKeys.Length - 1));
            colorKeys[i].color = Random.ColorHSV();
        }

        gradient.SetKeys(colorKeys, alphaKeys);
    }
}