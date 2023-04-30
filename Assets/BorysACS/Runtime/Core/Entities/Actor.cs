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

        #endregion
    }
}