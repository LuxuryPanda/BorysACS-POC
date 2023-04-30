using BorysACS.Core;
using BorysACS.Demo.Scripts.Systems;
using UnityEngine;

namespace BorysACS.Demo.Scripts
{
    [CreateAssetMenu(fileName = "Context.Test.asset", menuName = "BorysACS/Demo/New Test Context", order = 0)]
    public class MyTestContext : Context
    {
        [SerializeField] private RunnerSystem runnerSystem;
        [SerializeField] private SwerveSystem swerveSystem;
        
        public override void Initialize()
        {
            base.Initialize();
            AddSystemFixed(runnerSystem);
            AddSystemFixed(swerveSystem);

            Debug.Log("MyTestContext initialized.");
        }
        
        
    }
}