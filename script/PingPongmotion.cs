using UnityEngine;

public class PingPongmotion : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of vertical movement
    public float moveDistance = 5f; // Distance to move up or down
    private float initialY; // Store initial Y position

    void Start()
    {
        // Store the initial Y position of the object
        initialY = transform.position.y;
    }

    void Update()
    {
        // Move the object upwards and downwards along the Y axis using PingPong
        float newY = initialY + Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        // Update the object's position while keeping X and Z fixed
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
