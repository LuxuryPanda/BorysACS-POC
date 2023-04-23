﻿/***
 *
 * @Author: Roman
 * @Created on: 23/04/23
 *
 * @Copyright (c) by BorysProductions 2022. All rights reserved.
 *
 ***/

using System.Collections.Generic;
using BorysACS.Core.Base;
using UnityEngine;

namespace BorysACS.Core
{
    public abstract class Context : ScriptableObject
    {
        #region ## Fields ##

        private List<BaseSystem> _systems;
        private List<BaseSystem> _systemsFixed;
        private List<BaseSystem> _systemsLate;

        #endregion

        #region ## Properties ##

        

        #endregion

        #region ## Initialization ##

        internal void Initialize()
        {
            _systems = new List<BaseSystem>();
            _systemsFixed = new List<BaseSystem>();
            _systemsLate = new List<BaseSystem>();
        }

        #endregion

        #region ## Additions ##

        public void AddSystem<T>(T system) where T : BaseSystem
        {
            _systems.Add(system);
        }
        
        public void AddSystemFixed<T>(T system) where T : BaseSystem
        {
            _systemsFixed.Add(system);
        }
        
        public void AddSystemLate<T>(T system) where T : BaseSystem
        {
            _systemsLate.Add(system);
        }

        #endregion
        
        #region ## Executions ##
        
        public virtual void ExecuteSystems()
        {
            for (int i = 0; i < _systems.Count; i++)
            {
                _systems[i].Execute();
            }
        }
        
        public virtual void ExecuteSystemsFixed()
        {
            for (int i = 0; i < _systemsFixed.Count; i++)
            {
                _systemsFixed[i].Execute();
            }
        }
        
        public virtual void ExecuteSystemsLate()
        {
            for (int i = 0; i < _systemsLate.Count; i++)
            {
                _systemsLate[i].Execute();
            }
        }
        
        #endregion
    }
}