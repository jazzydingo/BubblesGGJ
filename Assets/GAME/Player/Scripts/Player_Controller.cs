using System.Collections;
using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LayerMask groundLayer;
    public Animator animator;

    //Ground Collision Raycast Variables
    public Vector2 boxSize;
    public float castDistance;

    //Running stuff
    private float move;
    public float speed;

    //Jumping, Jump Buffering, & Coyote Time
    public float jumpStrength;
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    public float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    //Flipping right & left
    private bool isFacingRight = true;

    //Dash stuff
    private bool canDash = true;
    private bool isDashing;
    public float dashPower = 24f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;

    void Start() //runs on start
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update() //constantly running things
    {
        if (isDashing) // prevents other systems if dashing
        {
            return;
        }
        FallAnim();
        Coyote();
        JumpBuffer();
        Run();
        Jump();
        Dashing();
        Flip();
    }
    private void Run() //Horizontal Movement
    {
        move = Input.GetAxisRaw("Horizontal");
        {
            myRigidbody.linearVelocity = new Vector2(move * speed, myRigidbody.linearVelocityY);
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }
    private void Jump() //Jumping
    {
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocityX,jumpStrength);
        }
        if (Input.GetKeyUp(KeyCode.Space) && myRigidbody.linearVelocityY > 0f)
        {
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocityX, myRigidbody.linearVelocityY * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }
    private void Dashing() //Dashing
    {
        if (Input.GetKeyDown (KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void Flip() //Flipping character L/R
    {
        if (isFacingRight && move < 0f || !isFacingRight && move > 0f)
                {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void Coyote() //Coyote Time
    {
        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }
    private void JumpBuffer() //Jump Buffering
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }
    public bool isGrounded() //Ground Check
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void FallAnim()//Fall Animation Checks
    {
        animator.SetBool("isJumping", !isGrounded() && myRigidbody.linearVelocityY >= 0f);
        animator.SetBool("isFalling", !isGrounded() && myRigidbody.linearVelocityY < 0f);
    }
    private void OnDrawGizmos() //Raycast Projection
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    private IEnumerator Dash() //Dash Code
    {
        canDash = false;
        isDashing = true;
        float originalGravity = myRigidbody.gravityScale;
        myRigidbody.gravityScale = 0f;
        myRigidbody.linearVelocity = new Vector2(transform.localScale.x * dashPower, 0f);
        yield return new WaitForSeconds(dashTime);
        myRigidbody.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}