using UnityEngine;

public class PingPongmotion2 : MonoBehaviour
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
        // This will make the object move between initialY - moveDistance and initialY + moveDistance
        float newY = initialY + Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;

        // Update the object's position while keeping X and Z fixed
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
