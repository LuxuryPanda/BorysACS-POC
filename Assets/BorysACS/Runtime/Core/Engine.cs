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
    /// Core behaviour of the BorysACS framework.
    /// </summary>
    public class Engine : MonoBehaviour
    {
        #region ## Fields ##
        
        private static Engine _instance;
        private Context _context;
        private World _world;
        
        private bool _canExecute = false;

        #endregion

        #region ## Properties ##

        public Context Context => _context;
        
        public World World => _world;

        #endregion

        #region ## Unity Methods ##

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
        }
        
        private void Update()
        {
            ExecuteSystems();
        }
        
        private void FixedUpdate()
        {
            ExecuteSystemsFixed();
        }
        
        private void LateUpdate()
        {
            ExecuteSystemsLate();
        }

        #endregion

        #region ## Initialization ##
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoad()
        {
            if (_instance == null)
            {
                var gameObject = new GameObject("Engine");
                _instance = gameObject.AddComponent<Engine>();
                
                // Not sure whether it should be persistent or not.
                //DontDestroyOnLoad(gameObject);
            }
        }
        
        private void Initialize()
        {
            _instance = this;
            InitializeContext();
            InitializeWorld();
        }

        private void InitializeContext()
        {
            _context = ScriptableDirector.GetInherited<Context>();
            if (_context != null)
            {
                _context.Initialize();
                _canExecute = true;
            }
        }
        
        private void InitializeWorld()
        {
            _world = ScriptableDirector.GetInherited<World>();
            if (_world != null) _world.Initialize();
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
            if (_context != null)
            {
                _context.ExecuteSystems();
            }
        }
        
        private void ExecuteSystemsFixed()
        {
            if (_context != null)
            {
                _context.ExecuteSystemsFixed();
            }
        }
        
        private void ExecuteSystemsLate()
        {
            if (_context != null)
            {
                _context.ExecuteSystemsLate();
            }
        }
        
        #endregion
    }
}