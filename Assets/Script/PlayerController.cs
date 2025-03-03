using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    public float jumpForce = 8f;
    private Rigidbody rb;
    private bool isGrounded = true;
    private int jumpCount = 0; 
    public int maxJumps = 2;  
    public Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Check if the player presses jump and has remaining jumps
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;  // Reset jump count when touching the ground
        }
    }
}
