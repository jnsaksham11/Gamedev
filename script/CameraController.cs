using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float smoothTime = 0.3f; // Time for smooth damping
    public float followThreshold = 0.1f; // Minimum x-movement required to move the camera

    private float lastCameraX; // Track the camera's last x-position
    private Vector3 velocity = Vector3.zero; // For SmoothDamp calculations

    void Start()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform is not assigned!");
            return;
        }

        // Initialize the last camera position to avoid jitter
        lastCameraX = transform.position.x;
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        float playerXMovement = Mathf.Abs(player.position.x - lastCameraX);

        // Check if player movement exceeds the threshold
        if (playerXMovement > followThreshold)
        {
            // Calculate the target position
            Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

            // Ensure the x position is not less than zero
            desiredPosition.x = Mathf.Max(desiredPosition.x, 0);

            // Smoothly move the camera to the target position
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

            // Update the last camera x-position
            lastCameraX = transform.position.x;
        }
    }
}
