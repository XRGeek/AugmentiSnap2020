using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FrontCameraSetup : MonoBehaviour
{
    public AROcclusionManager occlusionManager;
    public Material backgroundRenderer;

    void Start()
    {
        // Get a list of available devices (cameras)
        WebCamDevice[] devices = WebCamTexture.devices;

        // Find the front camera
        WebCamDevice frontCamera = FindFrontFacingCamera(devices);

        // If front camera is found, assign it to AROcclusionManager
        if (frontCamera.name != "")
        {
            // Set the camera source to the front camera
            occlusionManager.requestedHumanStencilMode = HumanSegmentationStencilMode.Fastest;
            occlusionManager.requestedHumanDepthMode = HumanSegmentationDepthMode.Fastest;
            occlusionManager.requestedEnvironmentDepthMode = EnvironmentDepthMode.Fastest;

            // Use the front camera for background rendering
            WebCamTexture webcamTexture = new WebCamTexture(frontCamera.name);
            backgroundRenderer.mainTexture = webcamTexture;
            webcamTexture.Play();

        }
        else
        {
            Debug.LogError("Front camera not found.");
        }
    }

    WebCamDevice FindFrontFacingCamera(WebCamDevice[] devices)
    {
        foreach (var device in devices)
        {
            if (device.isFrontFacing)
                return device;
        }
        return new WebCamDevice(); // If not found, return an empty device
    }
}
