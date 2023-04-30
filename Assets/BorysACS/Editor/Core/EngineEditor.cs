using System;
using BorysACS.Core;
using BorysACS.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace BorysACS.Editor.Core
{
    [CustomEditor(typeof(Engine))]
    public class EngineEditor : UnityEditor.Editor
    {
        #region ## Fields ##
        
        

        #endregion

        #region ## Properties ##

        private Engine Target => (Engine) base.target;

        #endregion
        
        #region ## Unity Methods ##

        private void OnEnable()
        {
        }

        #endregion
        
        #region ## Drawing Core ##
        
        public override void OnInspectorGUI()
        {
            EditorDrawer.DrawHeader("Engine", 10, 20);
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Context", Target.Context, typeof(Context), true);
            EditorGUILayout.ObjectField("World", Target.World, typeof(World), true);
            GUI.enabled = true;
        }
        
        #endregion
    }
}