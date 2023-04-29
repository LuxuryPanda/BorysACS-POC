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

        private Dictionary<string, Component> _componentsByName = new();
        
        [SerializeField, HideInInspector] private List<Component> components = new();

        #endregion

        #region ## Properties ##



        #endregion

        #region ## Unity Methods ##

        private void Awake()
        {
            InitializeActor();
        }

        #endregion

        #region ## Initialization ##

        private void InitializeActor()
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
    }
}