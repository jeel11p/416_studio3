using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    // Dash settings
    public float dashSpeed = 24f;  
    public float dashDuration = 0.2f;  
    public float dashCooldown = 1f;  

    private float dashTime = 0f;  
    private float dashCooldownTime = 0f;  
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing on " + gameObject.name);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTime <= 0f)
        {
            StartDash();
        }

        if (dashTime > 0f)
        {
            dashTime -= Time.deltaTime;
            PerformDash();
        }

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

        // Use player's forward direction if no input is detected
        if (dashDirection == Vector3.zero)
        {
            dashDirection = transform.forward;
        }

        rb.linearVelocity = dashDirection.normalized * dashSpeed;
    }
}
