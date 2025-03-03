using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    // Dash settings
    public float dashSpeed = 24f; 
    public float dashDuration = 0.2f; // Dash duration in seconds
    public float dashCooldown = 1f; 

    private float dashTime = 0f; // Timer for dash duration
    private float dashCooldownTime = 0f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTime <= 0f)
        {
            StartDash();
        }

        // Handle dash duration and apply dash movement
        if (dashTime > 0f)
        {
            dashTime -= Time.deltaTime;
            PerformDash();
        }

        // Handle cooldown time for the next dash
        if (dashCooldownTime > 0f)
        {
            dashCooldownTime -= Time.deltaTime;
        }
    }
    private void StartDash()
    {
        dashTime = dashDuration;
        dashCooldownTime = dashCooldown; 
    }

    private void PerformDash()
    {
        Vector3 dashDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.linearVelocity = dashDirection.normalized * dashSpeed; 
    }
}
