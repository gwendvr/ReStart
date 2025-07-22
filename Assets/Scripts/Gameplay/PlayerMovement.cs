using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float wallSlideSpeed = 2f;

    [Header("jump")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [Header("Respawn")]
    [SerializeField] private LayerMask spikeLayer;

    [Header("Wall Detection")]
    [SerializeField] private Transform wallCheckLeft;
    [SerializeField] private Transform wallCheckRight;
    [SerializeField] private Vector2 wallCheckSize = new Vector2(0.1f, 0.5f);

    [Header("UI")]
    [SerializeField] private SceneFader sceneFader;

    private Rigidbody2D rb;
    private InputSystem_Actions controls;
    private Vector2 moveInput;
    private bool isJumping;
    private bool isGrounded;
    private bool isTouchingWallLeft;
    private bool isTouchingWallRight;
    private bool isTouchingSpike;

    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Jump.performed += ctx => AttemptJump();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        LayerMask combinedWallLayers = groundLayer | wallLayer;
        isTouchingWallLeft = Physics2D.OverlapBox(wallCheckLeft.position, wallCheckSize, 0f, combinedWallLayers);
        isTouchingWallRight = Physics2D.OverlapBox(wallCheckRight.position, wallCheckSize, 0f, combinedWallLayers);
        
        isTouchingSpike = Physics2D.OverlapCircle(transform.position, 0.3f, spikeLayer);
        
        if (isTouchingSpike)
        {
            Respawn();
        }
    }

    private void FixedUpdate()
    {
        float horizontalMovement = moveInput.x * moveSpeed;
        
        if (isTouchingWallLeft && moveInput.x < 0)
        {
            horizontalMovement = 0;
        }
        else if (isTouchingWallRight && moveInput.x > 0)
        {
            horizontalMovement = 0;
        }
        
        rb.linearVelocity = new Vector2(horizontalMovement, rb.linearVelocity.y);
        
        bool isWallSliding = (isTouchingWallLeft || isTouchingWallRight) && !isGrounded;
        if (isWallSliding && rb.linearVelocity.y < 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -wallSlideSpeed));
        }

        if (isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
        }
    }

    private void AttemptJump()
    {
        if (isGrounded)
        {
            isJumping = true;
        }
    }

    private void Respawn()
    {
        sceneFader.FadeAndReload();
    }
}
