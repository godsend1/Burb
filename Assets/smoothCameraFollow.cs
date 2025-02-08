using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform player; // Assign Player Transform in Inspector
    public float smoothSpeed = 0.1f; // Adjust for more or less delay
    public Vector3 offset = new Vector3(0, 2, -5); // Adjust for best view

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player == null) return;

        // Target position with offset
        Vector3 targetPosition = player.position + offset;

        // Smoothly move towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}