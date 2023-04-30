/***
 *
 * @Author: Roman
 * @Created on: 23-04-23
 *
 * @Copyright (c) by BorysProductions 2022. All rights reserved.
 *
 ***/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BorysACS.Core.Entities
{
    /// <summary>
    /// Base component for all actors in the game.
    /// </summary>
    [AddComponentMenu("BorysACS/Entities/Actor"), DisallowMultipleComponent]
    public class Actor : MonoBehaviour
    {
        #region ## Fields ##
        
        private GameObject _gameObject;
        private Transform _transform;

        private Dictionary<string, Component> _componentsByName = new();
        [SerializeField, HideInInspector] private List<Component> components = new();

        #endregion

        #region ## Properties ##
        
        public GameObject GameObject
        {
            get
            {
                if (_gameObject == null) InitializeCache();
                return _gameObject;
            }
        }
        
        public Transform Transform
        {
            get
            {
                if (_transform == null) InitializeCache();
                return _transform;
            }
        }

        #endregion

        #region ## Unity Methods ##

        private void Awake()
        {
            Initialize();
        }

        #endregion

        #region ## Initialization ##

        private void Initialize()
        {
            InitializeCache();
            InitializeComponents();
        }

        private void InitializeCache()
        {
            _transform = transform;
            _gameObject = gameObject;
        }
        
        private void InitializeComponents()
        {
            _componentsByName.Clear();
            components.Clear();
            
            var collectedComponents = GetComponents<Component>();
            
            
            foreach (var component in collectedComponents)
            {
                _componentsByName.Add(component.GetType().Name, component);
                components.Add(component);
            }
        }

        #endregion

        #region ## Components Core ##

        public void AddComponent<T>(T component) where T : Component
        {
            _componentsByName.Add(component.GetType().Name, component);
            components.Add(component);
        }
        
        public bool HasComponent<T>()
        {
            if (_componentsByName.ContainsKey(typeof(T).Name))
            {
                return true;
            }

            return components.Exists(x => x.GetType() == typeof(T));
        }

        #endregion

        #region ## Positions ##
        
        #region ### Getters ###
        
        public Vector3 GetPosition()
        {
            return Transform.position;
        }
        
        public float GetPositionX()
        {
            return Transform.position.x;
        }
        
        public float GetPositionY()
        {
            return Transform.position.y;
        }
        
        public float GetPositionZ()
        {
            return Transform.position.z;
        }
        
        #endregion
        
        #region ### Setters ###

        public void SetPosition(Vector3 position)
        {
            Transform.position = position;
        }
        
        public void SetPosition(float x, float y, float z)
        {
            Transform.position = new Vector3(x, y, z);
        }
        
        public void SetPositionX(float x)
        {
            Transform.position = new Vector3(x, Transform.position.y, Transform.position.z);
        }
        
        public void SetPositionY(float y)
        {
            Transform.position = new Vector3(Transform.position.x, y, Transform.position.z);
        }
        
        public void SetPositionZ(float z)
        {
            Transform.position = new Vector3(Transform.position.x, Transform.position.y, z);
        }

        #endregion

        #endregion

        
    }
}