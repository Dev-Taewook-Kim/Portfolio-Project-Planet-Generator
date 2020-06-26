using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetPreviewer))]
public class PlanetPreviewerEditor : Editor
{
    PlanetPreviewer targetObj = null;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUI.changed) targetObj.UpdateTexture();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Terrain Preview", EditorStyles.boldLabel);
        GUI.DrawTexture(GUILayoutUtility.GetAspectRect(1f), targetObj.planetObject.GetComponent<Renderer>().sharedMaterial.mainTexture, ScaleMode.ScaleAndCrop);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Cloud Preview", EditorStyles.boldLabel);
        GUI.DrawTexture(GUILayoutUtility.GetAspectRect(1f), targetObj.cloudObject.GetComponent<Renderer>().sharedMaterial.mainTexture, ScaleMode.ScaleAndCrop);
    }

    private void OnEnable()
    {
        if (targetObj == null) targetObj = (PlanetPreviewer)target;

        targetObj.InitObject();
    }
}