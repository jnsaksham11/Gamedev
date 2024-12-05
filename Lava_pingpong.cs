using UnityEngine;

public class Lava_pingpong : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of vertical movement
    public float moveDistance = 5f; // Distance to move up or down
    private float initialY; // Store initial Y position
    private bool isFlipped = false; // Track the current flip state

    void Start()
    {
        // Store the initial Y position of the object
        initialY = transform.position.y;
    }

    void Update()
    {
        // Calculate the new Y position using PingPong
        float newY = initialY + Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        // Check if the object is moving downward
        if (newY < transform.position.y && !isFlipped)
        {
            // Flip the object along the Y axis
            FlipObject();
            isFlipped = true;
        }
        // Check if the object is moving upward
        else if (newY > transform.position.y && isFlipped)
        {
            // Reset the object's scale to normal
            FlipObject();
            isFlipped = false;
        }

        // Update the object's position while keeping X and Z fixed
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void FlipObject()
    {
        // Flip the object's scale along the Y axis
        Vector3 currentScale = transform.localScale;
        currentScale.y *= -1;
        transform.localScale = currentScale;
    }
}
