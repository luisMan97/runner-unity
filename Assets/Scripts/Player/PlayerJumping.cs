using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    public bool isJumping;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rigidBody;
    private Animator animator;
    private InputManager inputManager;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float canJump = inputManager.jumping.ReadValue<float>();
        if (canJump == 1)
            Jump();
    }

    public void Jump()
    {
        if (!isJumping)
        {
            animator.SetTrigger("Jump");
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isJumping = false;
    }

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("LUIS EXIT");
            inGround = false;
        }
           
    }*/
}

