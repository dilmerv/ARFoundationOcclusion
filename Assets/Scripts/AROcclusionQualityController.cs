using DilmerGames.Core;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(AROcclusionManager))]
public class AROcclusionQualityController : Singleton<AROcclusionQualityController>
{
    private AROcclusionManager arOcclusionManager;

    void Awake()
    {
        arOcclusionManager = GetComponent<AROcclusionManager>();    
    }

    public void ChangeQualityTo(EnvironmentDepthMode environmentDepthMode)
    {
        arOcclusionManager.requestedEnvironmentDepthMode = environmentDepthMode;
    }

    public EnvironmentDepthMode GetCurrentDepthMode()
    {
        return arOcclusionManager.requestedEnvironmentDepthMode;
    }
}
