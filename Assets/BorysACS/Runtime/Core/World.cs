/***
 *
 * @Author: Roman
 * @Created on: 23-04-23
 *
 * @Copyright (c) by BorysProductions 2022. All rights reserved.
 *
 ***/

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

        private List<Actor> _actors;

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
    }
}