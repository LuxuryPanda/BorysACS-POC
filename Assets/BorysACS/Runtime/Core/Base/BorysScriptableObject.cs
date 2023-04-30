using UnityEngine;

namespace BorysACS.Core.Base
{
    public abstract class BorysScriptableObject : ScriptableObject
    {
        #region ## Fields ##
        
        /// <summary>
        /// Priority of the ScriptableObject, used to determine the order of search in case of multiple ScriptableObjects of the same type.
        /// </summary>
        [SerializeField] private int priority = 0;
        
        private bool _initialized;

        #endregion

        #region ## Properties ##
        
        public bool Initialized => _initialized;

        #endregion

        #region ## Initialization ##
        
        public virtual void Initialize()
        {
            if (_initialized) return;
            _initialized = true;
        }

        #endregion
    }
}