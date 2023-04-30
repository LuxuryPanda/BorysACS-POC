using BorysACS.Core.Base;
using UnityEngine;

namespace BorysACS.Demo.Scripts.Systems
{
    [CreateAssetMenu(fileName = "System.Swerve.asset", menuName = "BorysACS/Demo/Systems/New Swerve", order = 0)]
    public class SwerveSystem : BaseSystem
    {
        #region ## Fields ##

        [SerializeField] private float swerveSpeed = 2f;
        [SerializeField] private float swerveMagnitude = 2f;
        
        [Header("Limits")]
        [SerializeField] private float leftLimit = -6f;
        [SerializeField] private float rightLimit = 6f;

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
                {
                    var position = entity.GetPosition();
                    var swerve = Mathf.Sin(Time.time * swerveSpeed) * swerveMagnitude;
                    position.x = Mathf.Clamp(position.x + swerve, leftLimit, rightLimit);
                    entity.SetPosition(position);
                }
                    
            });
        }

        public override void ExecuteLate()
        {
        }
    }
}