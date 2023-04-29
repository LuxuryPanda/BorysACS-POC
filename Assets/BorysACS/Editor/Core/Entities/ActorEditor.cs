using System;
using BorysACS.Core.Entities;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace BorysACS.Editor.Core.Entities
{
    [CustomEditor(typeof(Actor))]
    public class ActorEditor : UnityEditor.Editor
    {
        #region ## Fields ##
        
        private ReorderableList _componentsList;
        private SerializedProperty _componentsProperty;
        private new Actor target => base.target as Actor;

        private static GUIStyle _miniToggle;

        #endregion

        #region ## Unity Methods ##

        private void OnEnable()
        {
            var minusIcon = EditorGUIUtility.IconContent("Toolbar Minus");
            var plusIcon = EditorGUIUtility.IconContent("Toolbar Plus");
            
            _componentsProperty = serializedObject.FindProperty("components");
            _componentsList = new ReorderableList(serializedObject, _componentsProperty)
            {
                elementHeight = 18,
                footerHeight = 0,
                displayAdd = false, displayRemove = false,
                draggable = false,
                drawFooterCallback = null
            };

            _componentsList.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                if (index >= _componentsProperty.arraySize)
                {
                    Debug.LogWarning("Index out of range");
                    return;
                }

                var element = _componentsProperty.GetArrayElementAtIndex(index);

                rect.yMin += 1;
                rect.yMax -= 1;

                // Let it be readonly
                GUI.enabled = false;
                EditorGUI.PropertyField(rect, element, GUIContent.none);
                rect.x += rect.width + 5;
                GUI.enabled = true;
            };

            _componentsList.drawHeaderCallback = rect =>
            {
                rect.xMin -= 5;
                rect.xMax += 5;
                
                // Components count
                GUI.enabled = false;
                EditorGUI.IntField(new Rect(rect) { width = 35 }, _componentsProperty.arraySize);
                GUI.enabled = true;
                
                // Title
                rect.x += 40;
                EditorGUI.LabelField(rect, "Components", EditorStyles.miniLabel);
            };
        }

        #endregion
        
        #region ## Drawing Core ##
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(10);
            serializedObject.Update();
            
            if (_miniToggle == null)
            {
                _miniToggle = "ShurikenToggle";
            }
            
            // Drawing the list in playmode-only, since it is for debug purposes only
            if (Application.isPlaying)
            {
                GUILayout.Space(-5);
                _componentsList.DoLayoutList();
            }

        }
        
        #endregion
    }
}