using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ColorSetting))]
public class ColorSettingEditor : Editor
{
    ColorSetting targetObj = null;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Set Default")) targetObj.SetDefault();

        if (GUILayout.Button("Generate Random")) targetObj.GenerateRandom();
    }

    private void OnEnable()
    {
        if (targetObj == null) targetObj = (ColorSetting)target;
    }
}