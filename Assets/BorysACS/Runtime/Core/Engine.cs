/***
 *
 * @Author: Roman
 * @Created on: 23-04-23
 *
 * @Copyright (c) by BorysProductions 2022. All rights reserved.
 *
 ***/

using System.Collections.Generic;
using System.Linq;
using BorysACS.Core.Base;
using BorysACS.Core.Entities;
using BorysACS.Tools;
using UnityEngine;


namespace BorysACS.Core
{
    /// <summary>
    /// Core behaviour of the BorysACS framework. It is responsible for the 
    /// </summary>
    public class Engine : MonoBehaviour
    {
        #region ## Fields ##
        
        private static Engine _instance;
        private Context _context;
        private World _world;

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
        
        private void Update()
        {
            
        }
        
        private void FixedUpdate()
        {
            
        }
        
        private void LateUpdate()
        {
            
        }

        #endregion

        #region ## Initialization ##

        private void Initialize()
        {
            _instance = this;
            InitializeContext();
            InitializeWorld();
        }

        private void InitializeContext()
        {
            _context = ScriptableDirector.Get<Context>();
            _context.Initialize();
        }
        
        private void InitializeWorld()
        {
            _world = ScriptableDirector.Get<World>();
            _world.Initialize();
        }

        #endregion
        
        #region ## Core ##

        public static void AddSystem<T>(T system) where T : BaseSystem
        {
            _instance._context.AddSystem(system);
        }

        #endregion
        
        #region ## Executions ##
        
        /// <summary>
        /// Executes all systems in the game Update loop.
        /// </summary>
        private void ExecuteSystems()
        {
            _context.ExecuteSystems();
        }
        
        private void ExecuteSystemsFixed()
        {
            _context.ExecuteSystemsFixed();
        }
        
        private void ExecuteSystemsLate()
        {
            _context.ExecuteSystemsLate();
        }
        
        #endregion
    }
}