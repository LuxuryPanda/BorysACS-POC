/***
 *
 * @Author: Roman
 * @Created on: 23/04/23
 *
 * @Copyright (c) by BorysProductions 2022. All rights reserved.
 *
 ***/

using UnityEngine;

namespace BorysACS.Core.Base
{
    /// <summary>
    /// Base class representing a system. A system is a ScriptableObject responsible for controlling a specific logic of the game.
    /// </summary>
    public abstract class BaseSystem : ScriptableObject
    {
        #region ## Fields ##
        
        /// <summary>
        /// Unique identifier of the system.
        /// </summary>
        private int _id;
        
        /// <summary>
        /// Priority of the system. The lower the priority, the earlier the system will be executed.
        /// </summary>
        private int _priority;

        #endregion

        #region ## Properties ##
        
        /// <summary>
        /// Unique identifier of the system.
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }
            
        /// <summary>
        /// Priority of the system. The lower the priority, the earlier the system will be executed.
        /// </summary>
        public int Priority
        {
            get => _priority;
            set => _priority = value;
        }

        #endregion

        #region ## Life-Cycle ##

        public abstract void OnAwake();
        
        public abstract void OnStart();
        
        public abstract void OnEnable();

        public virtual void OnDisable()
        {
        }

        public abstract void OnApplicationQuit();

        #endregion
        
        #region ## Core ##
        
        /// <summary>
        /// Executes a logic in the game Update loop.
        /// </summary>
        public abstract void Execute();
        
        /// <summary>
        /// Executes a logic in the game FixedUpdate loop.
        /// </summary>
        public abstract void ExecuteFixed();
        
        /// <summary>
        /// Executes a logic in the game LateUpdate loop.
        /// </summary>
        public abstract void ExecuteLate();

        #endregion
    }
}