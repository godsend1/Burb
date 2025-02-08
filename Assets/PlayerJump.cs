using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 7f;    // How high the player jumps
    public LayerMask groundLayer;   // Layer to check for ground
    public Transform groundCheck;   // A transform at player's feet

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckGrounded();  // Continuously check if we're on the ground

        if (Input.GetKeyDown(KeyCode.E) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset Y velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump force
    }


    void CheckGrounded()
    {
        float rayDistance = 0.5f; // Try 0.5 or more
        bool centerCheck = Physics.Raycast(transform.position, Vector3.down, rayDistance, groundLayer);
        bool leftCheck = Physics.Raycast(transform.position + Vector3.left * 0.3f, Vector3.down, rayDistance, groundLayer);
        bool rightCheck = Physics.Raycast(transform.position + Vector3.right * 0.3f, Vector3.down, rayDistance, groundLayer);

        isGrounded = centerCheck || leftCheck || rightCheck;
    }
}