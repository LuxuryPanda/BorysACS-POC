/***
 *
 * @Author: Roman
 * @Created on: 23-04-23
 *
 * @Copyright (c) by BorysProductions 2022. All rights reserved.
 *
 ***/

using System;
using System.Collections.Generic;
using BorysACS.Core.Base;
using BorysACS.Core.Entities;
using UnityEngine;


namespace BorysACS.Core
{
    /// <summary>
    /// The World is the main operating system in the game.
    /// It is responsible for creating, updating and destroying all actors in the game.
    /// </summary>
    public class World : BorysScriptableObject
    {
        #region ## Fields ##

        [SerializeField] private List<Actor> _actors = new List<Actor>();

        #endregion

        #region ## Properties ##



        #endregion

        #region ## Unity Methods ##

        private void Awake()
        {

        }

        private void Start()
        {

        }

        #endregion

        #region ## Initialization ##

        public override void Initialize()
        {
            base.Initialize();
            InitializeActors();
        }
        
        private void InitializeActors()
        {
            _actors = new List<Actor>();
            _actors.AddRange(FindObjectsOfType<Actor>());
        }

        #endregion
        
        #region ## Core ##

        

        #endregion

        #region ## For All ##

        public void ForAllActors(Action<Actor> callback)
        {
            foreach (var actor in _actors)
            {
                callback?.Invoke(actor);
            }
        }
        
        public void ForAllActors<T>(Action<T> callback) where T : Actor
        {
            foreach (var actor in _actors)
            {
                if (actor is T requestedActor)
                {
                    callback?.Invoke(requestedActor);
                }
            }
        }

        #endregion
    }
}