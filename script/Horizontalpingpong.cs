using UnityEngine;

public class Horizontalpingpong : MonoBehaviour
{
    public float speed = 2f;    // Speed of the movement
    public float distance = 3f; // Distance to move away from the initial position

    private float initialX;    // The object's starting X position
    public bool movingRight = true;

    void Start()
    {
        // Record the initial X position of the object
        initialX = transform.position.x;
    }

    void Update()
    {
        // Calculate the boundaries relative to the initial position
        float minX = initialX - distance;
        float maxX = initialX + distance;

        // Move the object horizontally based on the speed and direction
        float moveDirection = movingRight ? 1 : -1;
        transform.Translate(Vector3.right * speed * moveDirection * Time.deltaTime);

        // Check if the object has reached or passed the maxX or minX position
        if (transform.position.x >= maxX)
        {
            movingRight = false;  // Change direction to left
        }
        else if (transform.position.x <= minX)
        {
            movingRight = true;   // Change direction to right
        }
    }
}
