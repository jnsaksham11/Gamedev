using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float fixedYPosition = 0f; // The constant y-position for the camera
    public float minXPosition = 0f;  // Minimum x-position for the camera

    private Transform parentTransform; // Reference to the parent (player)

    void Start()
    {
        // Ensure the script is attached to the camera and has a parent
        parentTransform = transform.parent;

        if (parentTransform == null)
        {
            Debug.LogError("The camera must be a child of the player to use this script!");
        }
    }

    void LateUpdate()
    {
        if (parentTransform == null)
            return;

        // Restrict the camera's y-position and ensure x-position is not less than the minimum
        float clampedX = Mathf.Max(parentTransform.position.x, minXPosition);
        transform.position = new Vector3(clampedX, fixedYPosition, transform.position.z);
    }
}
