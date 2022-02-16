using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isJumping;
    public bool doubleJump;
    public bool isGrounded;
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public static PlayerMovement instance;
    private float horizontalMovement;
    public int nbPiles = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }
        instance = this;
    }

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        if (isJumping == true && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
            doubleJump = true;
        }
        else
        {
            if (doubleJump == true && isJumping == true)
            {
                rb.AddForce(new Vector2(0f, jumpForce / 2));
                doubleJump = false;
                
            }
        }

        if (isGrounded==false)
        {
            animator.SetBool("isJump",true);
        }
        if(isGrounded==true)
        {
            animator.SetBool("isJump",false);
        }
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}

