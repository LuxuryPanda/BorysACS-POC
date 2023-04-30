using System;
using UnityEngine;

namespace BorysACS.Utils.Extensions
{
    public static class GameObjectExt
    {
        #region ## Creation ##

        public static T CreateNew<T>(this Type type) where T : Component
        {
            return CreateNew<T>(type.Name);
        }
        
        public static T CreateNew<T>(this Type type, string name) where T : Component
        {
            return CreateNew<T>(name);
        }
        
        public static T CreateNew<T>(string name) where T : Component
        {
            var gameObject = new GameObject(name);
            return gameObject.AddComponent<T>();
        }
        
        public static GameObject CreateChild(this GameObject parent, string name)
        {
            var child = new GameObject(name);
            child.transform.SetParent(parent.transform);
            return child;
        }

        #endregion
    }
}