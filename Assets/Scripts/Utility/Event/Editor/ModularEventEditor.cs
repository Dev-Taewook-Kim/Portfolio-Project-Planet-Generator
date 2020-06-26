using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace P2Playworks.ModularFrameworks
{
    [CustomEditor(typeof(ModularEvent))]
    public class ModularEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            ModularEvent m = target as ModularEvent;

            if (GUILayout.Button("Raise"))
            {
                m.Raise();
            }
        }
    }
}
