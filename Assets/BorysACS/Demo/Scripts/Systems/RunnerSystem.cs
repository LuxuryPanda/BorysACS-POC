using BorysACS.Core.Base;
using UnityEngine;

namespace BorysACS.Demo.Scripts.Systems
{
    [CreateAssetMenu(fileName = "System.Runner.asset", menuName = "BorysACS/Demo/Systems/New Runner", order = 0)]
    public class RunnerSystem : BaseSystem
    {
        #region ## Fields ##
        
        [SerializeField] private float speed = 1f;

        #endregion

        #region ## Properties ##
        
        

        #endregion


        public override void OnAwake()
        {
        }

        public override void OnStart()
        {
        }

        public override void OnEnable()
        {
        }

        public override void OnApplicationQuit()
        {
        }

        public override void Execute()
        {
        }

        public override void ExecuteFixed()
        {
            World.ForAllActors(entity =>
            {
                if (entity.HasComponent<MeshRenderer>())
                    entity.SetPositionZ(entity.GetPositionZ() + speed * Time.fixedDeltaTime);
            });
        }

        public override void ExecuteLate()
        {
        }
    }
}