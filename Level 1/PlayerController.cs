using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

 public float moveSpeed = 5f;
 public float jumpForce = 5f;
 public Transform groundCheck;
 public LayerMask groundLayer;

 private Rigidbody2D  rd;
 private bool isGrounded;
 private float moveInput;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
      rd.linearVelocity = new Vector2(moveInput * moveSpeed, rd.linearVelocity.y);
      
      isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
    public void OnMove(InputValue value)
    {
     Vector2 input = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rd.linearVelocity = new Vector2(rd.linearVelocity.x, 0f);
            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

}
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.CompareTag("Respwn"))
       {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
   }
   
 }