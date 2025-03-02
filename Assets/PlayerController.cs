using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    public float jumpForce = 8f;
    
    private Rigidbody rb;
    private bool isGrounded = true;
    
    public Transform cameraTransform; // Reference to the camera

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Get camera's forward and right directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Flatten the Y-axis to prevent tilting the player
        forward.y = 0;
        right.y = 0;

        // Normalize to maintain consistent movement speed
        forward.Normalize();
        right.Normalize();

        // Calculate movement direction based on camera
        Vector3 moveDirection = forward * verticalInput + right * horizontalInput;

        // Move the player
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Rotate player to face movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10f);
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
