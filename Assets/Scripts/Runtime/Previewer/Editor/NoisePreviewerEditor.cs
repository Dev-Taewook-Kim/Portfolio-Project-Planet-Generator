using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NoisePreviewer))]
public class NoisePreviewerEditor : Editor
{
    NoisePreviewer targetObj;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUI.changed) if (targetObj.drawMode == NoisePreviewer.DrawMode.Preset && targetObj.noisePreset == null) targetObj.drawMode = NoisePreviewer.DrawMode.Value;
        if (GUI.changed) targetObj.UpdateTexture();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Texture Preview", EditorStyles.boldLabel);
        GUI.DrawTexture(GUILayoutUtility.GetAspectRect(1f), targetObj.viewerObject.GetComponent<Renderer>().sharedMaterial.mainTexture, ScaleMode.ScaleAndCrop);
    }

    private void OnEnable()
    {
        if (targetObj == null) targetObj = target as NoisePreviewer;//targetObj = (NoisePreviewer)target;

        targetObj.InitObject();
    }
}