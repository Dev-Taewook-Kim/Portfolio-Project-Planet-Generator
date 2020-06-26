using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace P2Playworks.ModularFrameworks
{
    public abstract class BaseReferenceDrawer : PropertyDrawer
    {
        private readonly string[] options = { "Use Constant", "Use Variable" };

        private GUIStyle style;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //base.OnGUI(position, property, label);

            if (style == null)
            {
                style = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                style.imagePosition = ImagePosition.ImageOnly;
            }

            position = EditorGUI.PrefixLabel(position, label);
            label = EditorGUI.BeginProperty(position, label, property);

            EditorGUI.BeginChangeCheck();

            //Get Properties
            SerializedProperty useConstant = property.FindPropertyRelative("useConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("constantValue");
            SerializedProperty variable = property.FindPropertyRelative("Variable");

            //Calculate Rect for Configuration Button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += style.margin.top;
            buttonRect.width = style.fixedWidth + style.margin.right;
            position.xMin = buttonRect.xMax;
            
            //Store Old Indent Level and Set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, options, style);

            useConstant.boolValue = result == 0;

            if (useConstant.boolValue && constantValue.propertyType == SerializedPropertyType.Vector4)
            {
                EditorGUI.Vector4Field(position, GUIContent.none, constantValue.vector4Value);
            }
            else
            {
                EditorGUI.PropertyField(position, useConstant.boolValue ? constantValue : variable, GUIContent.none);
            }

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
            }
            
            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}
