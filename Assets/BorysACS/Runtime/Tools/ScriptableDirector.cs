/***
 *
 * @Author: Roman
 * @Created on: 23/04/23
 *
 * @Copyright (c) by BorysProductions 2022. All rights reserved.
 *
 ***/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BorysACS.Tools
{
    [CreateAssetMenu(fileName = "Director.Scriptable", menuName = "BorysACS/Tools/ScriptableDirector")]
    public class ScriptableDirector : ScriptableObject
    {
        #region ## Fields ##

#if UNITY_EDITOR
        [SerializeField, Header("Configuration"), Tooltip("Automatically force load on play mode start")]
        public bool autoLoadOnEnable = true;
#endif

        private List<ScriptableObject> _scriptableObjects = new();
        private Dictionary<string, ScriptableObject> _scriptableObjectsByName = new();

        [SerializeField] private List<string> searchPaths = new()
        {
            "/Assets"
        };

        [SerializeField] private List<string> excludedNamespaces = new()
        {
            "BorysToolkit.Editor"
        };

#if UNITY_EDITOR
        private readonly List<System.Type> _editorOnlyTypes = new List<System.Type>()
        {
#if TEXT_MESH_PRO
            typeof(TMPro.TMP_FontAsset),
            typeof(TMPro.TMP_SpriteAsset),
#endif
            typeof(GUISkin)
        };
#endif

        #endregion

        #region ## Properties ##

        public static ScriptableDirector Instance { get; private set; }

        #endregion

        #region ## Unity Methods ##

        private void OnEnable()
        {
            Instance = this;
#if UNITY_EDITOR
            if (autoLoadOnEnable)
                RefreshDatabase();
#endif
        }

        #endregion

        #region ## Static Core ##

        public static T Get<T>() where T : ScriptableObject
        {
            if (Instance == null)
                return null;

            if (Instance._scriptableObjectsByName.TryGetValue(typeof(T).Name, out var scriptableObject))
                return scriptableObject as T;

            return Instance.Load<T>();
        }

        #endregion
        
        #region ## Core ##

        private T Load<T>() where T : ScriptableObject
        {
            // TODO
            return null;
        }

        #endregion

        #region ## Editor ##

#if UNITY_EDITOR

        // In the inspector draw a button to force load the database
        private void RefreshDatabase()
        {
            _scriptableObjects.Clear();
            _scriptableObjectsByName.Clear();

            var guids = UnityEditor.AssetDatabase.FindAssets("t:ScriptableObject", searchPaths.ToArray());
            foreach (var guid in guids)
            {
                var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                var scriptableObject = UnityEditor.AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
                if (scriptableObject == null)
                    continue;

                if (excludedNamespaces.Contains(scriptableObject.GetType().Namespace))
                    continue;

                if (_editorOnlyTypes.Contains(scriptableObject.GetType()))
                    continue;

                _scriptableObjects.Add(scriptableObject);
                _scriptableObjectsByName.Add(scriptableObject.name, scriptableObject);
            }
        }
#endif

        #endregion
    }
}