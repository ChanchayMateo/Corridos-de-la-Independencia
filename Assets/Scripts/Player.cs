using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 4;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public int extraJumpsValue = 1;
    public Animator animator;

    private Rigidbody2D rb2D;
    private float move;
    private bool isGrounded;
    private int extraJumps;

    
    private IPlayerState currentState;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        
        ChangeState(new GroundedState());
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        
        currentState?.UpdateState(this);

        if (move != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetFloat("VerticalVelocity", rb2D.linearVelocity.y);
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void ChangeState(IPlayerState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void ExecuteJump() => rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
    public bool CheckIsGrounded() => isGrounded;
    public bool CanExtraJump() => extraJumps > 0;
    public void ResetExtraJumps() => extraJumps = extraJumpsValue;
    public void DecrementExtraJump() => extraJumps--;
}