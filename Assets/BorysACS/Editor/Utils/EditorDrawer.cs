using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BorysACS.Editor.Utils
{
    /// <summary>
    /// Utility class for drawing commonly used GUI elements in the editor.
    /// </summary>
    public static class EditorDrawer
    {
        #region ## Headers ##
        
        public static void DrawHeader(string text, float paddingTop = 5, float paddingBottom = 10)
        {
            DrawHeader(text, 16, TextAnchor.MiddleCenter, paddingTop, paddingBottom);
        }

        public static void DrawHeader(string text, int fontSize = 16, TextAnchor alignment = TextAnchor.MiddleCenter, float paddingTop = 5, float paddingBottom = 10)
        {
            GUILayout.Space(paddingTop);
            GUILayout.Label(text, new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = fontSize,
                fontStyle = FontStyle.Bold,
                alignment = alignment,
                wordWrap = true
            });
            GUILayout.Space(paddingBottom);
        }

        #endregion

        #region ## Properties ##
        
        public static void HorizontalPropertyField(string label, float labelWidth, SerializedProperty property, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, EditorStyles.label, GUILayout.Width(labelWidth));
            EditorGUILayout.PropertyField(property, true);
            EditorGUILayout.EndHorizontal();
        }

        #endregion
    }
}