using UnityEngine;
using Cinemachine; // Required for Cinemachine

public class CameraZoom : MonoBehaviour
{
    [Header("Zoom Settings")]
    public float zoomSpeed = 10f;  // Zoom speed
    public float minFOV = 20f;     // Min zoom (closer)
    public float maxFOV = 60f;     // Max zoom (farther)

    private CinemachineVirtualCamera virtualCam;  // Reference to the Cinemachine Camera

    void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();

        if (virtualCam == null)
        {
            Debug.LogError("CinemachineVirtualCamera component is missing from this GameObject.");
        }
    }

    void Update()
    {
        if (virtualCam == null) return;  // Prevent errors

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            float newFOV = virtualCam.m_Lens.FieldOfView - scrollInput * zoomSpeed;
            virtualCam.m_Lens.FieldOfView = Mathf.Clamp(newFOV, minFOV, maxFOV);

            Debug.Log("New Cinemachine FOV: " + virtualCam.m_Lens.FieldOfView);
        }
    }
}