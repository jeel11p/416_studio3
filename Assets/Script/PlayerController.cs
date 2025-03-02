using UnityEngine;


public class PlayerController : MonoBehaviour
{
   public float speed = 5.0f;
   private float horizontalInput;
   private float forwardInput;
   public float jumpForce = 8f;
   private Rigidbody rb;
   private bool isGrounded = true;
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


       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
       {
           rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           isGrounded = false;
       }
   }


   private void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.CompareTag("Ground"))
       {
           isGrounded = true;
       }
   }
}





