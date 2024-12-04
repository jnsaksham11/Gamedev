using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl2D : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 10f; // Adjust this for the desired jump height
    private Rigidbody2D body;
    private bool grounded;

    private void Awake()
    {
        // Grabs reference for Rigidbody2D
        body = GetComponent<Rigidbody2D>();
        //Debug.Log("Player Control Initialized");
    }

    private void Update()
    {
        // Get horizontal input for left and right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Flip the player based on direction
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }

        // Handle jump if the player is grounded
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            //Debug.Log("Jump triggered");
            Jump();
        }

        // Debug log to show current grounded status
        //Debug.Log("Grounded: " + grounded);
    }

    private void Jump()
    {
        // Apply upward force to jump
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        grounded = false;
        //Debug.Log("Jump executed with force: " + jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug log to check which object the player is colliding with
        //Debug.Log("Collided with: " + collision.gameObject.name);

        grounded = true;
    }

}
