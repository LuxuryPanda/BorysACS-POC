using System;
using System.Collections.Generic;
using BorysACS.Editor.Utils;
using BorysACS.Tools;
using UnityEditor;
using UnityEngine;

namespace BorysACS.Editor.Tools
{
    [CustomEditor(typeof(ScriptableDirector))]
    public class ScriptableDirectorEditor : UnityEditor.Editor
    {
        #region ## Fields ##

        private SerializedProperty _autoLoadOnEnable;
        private SerializedProperty _scriptableObjects;
        private SerializedProperty _searchPaths;
        private SerializedProperty _excludedNamespaces;
        
        private GUIStyle _headerStyle;

        #endregion
        
        #region ## Properties ##
        
        private ScriptableDirector Target => (ScriptableDirector) base.target;
        
        #endregion
        
        #region ## Unity Methods ##

        private void OnEnable()
        {
            _autoLoadOnEnable = serializedObject.FindProperty("autoLoadOnEnable");
            _scriptableObjects = serializedObject.FindProperty("_scriptableObjects");
            _searchPaths = serializedObject.FindProperty("searchPaths");
            _excludedNamespaces = serializedObject.FindProperty("excludedNamespaces");
        }
        
        #endregion
        
        #region ## Drawing Core ##

        public override void OnInspectorGUI()
        {
            EditorDrawer.DrawHeader("Scriptable Director", 10, 20);
            
            DrawConfiguration();
            DrawDatabaseContent();

            // Draw refresh button
            GUILayout.Space(20);
            if (GUILayout.Button("Refresh Database"))
            {
                Target.RefreshDatabase();
                serializedObject.ApplyModifiedProperties();
                Repaint();
            }
        }

        private void DrawConfiguration()
        {
            // Draw configuration
            EditorDrawer.DrawHeader("Configuration", 14, TextAnchor.MiddleLeft, 20, 0);
            EditorGUILayout.BeginHorizontal();
            _autoLoadOnEnable.boolValue = EditorGUILayout.Toggle("Auto load on enable", _autoLoadOnEnable.boolValue);
            EditorGUILayout.EndHorizontal();
            
            EditorDrawer.HorizontalPropertyField("Search Path", 160, _searchPaths);
            EditorDrawer.HorizontalPropertyField("Excluded Namespaces", 160, _excludedNamespaces);
        }

        private void DrawDatabaseContent()
        {
            // Draw database
            EditorDrawer.DrawHeader("Database", 14, TextAnchor.MiddleLeft, 20, 0);

            // Draw a small header box containing the number of elements in the database
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            
            // Draw header label with the number of elements in the database, aligned vertically to the center
            EditorGUILayout.LabelField($"[{_scriptableObjects.arraySize}]", EditorStyles.boldLabel);
            
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            GUI.enabled = false;
            // Manually draw scriptable objects list, so draw each element separately
            for (var i = 0; i < _scriptableObjects.arraySize; i++)
            {
                var element = _scriptableObjects.GetArrayElementAtIndex(i);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(element, GUIContent.none);
                EditorGUILayout.EndHorizontal();
            }

            GUI.enabled = true;
            EditorGUILayout.EndVertical();
        }

        #endregion
    }
}