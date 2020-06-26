using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NoiseSetting))]
public class NoiseSettingEditor : Editor
{
    private NoiseSetting targetObj = null;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Random")) targetObj.GenerateRandom();
    }

    private void OnEnable()
    {
        if (targetObj == null) targetObj = (NoiseSetting)target;
    }
}