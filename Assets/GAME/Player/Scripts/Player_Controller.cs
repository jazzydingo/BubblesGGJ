using System.Collections;
using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LayerMask groundLayer;
    public Animator animator;

    public GameObject sfxObj;

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

    public bool inJump = false;

    //Flipping right & left
    private bool isFacingRight = true;

    //Dash stuff
    private bool canDash = true;
    private bool isDashing;
    public float dashPower = 24f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;
    
    public bool wasGrounded;
    public bool landSound = false;

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
        move = InputSystem.actions["Move"].ReadValue<Vector2>().x;
        {
            myRigidbody.linearVelocity = new Vector2(move * speed, myRigidbody.linearVelocityY);
            if (move != 0)
            {
                animator.SetBool("isRunning", true);
                if(!isGrounded() && wasGrounded)
                {
                    wasGrounded = false; 
                    landSound = false;
                    StartCoroutine(WaitUntilLand());
                }
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
        if(Input.GetKeyDown(KeyCode.Space) && !inJump)
        {
            inJump = true;
            landSound = false;
            AkSoundEngine.PostEvent("octo_jump", sfxObj);
            
        }
        if (Input.GetKeyUp(KeyCode.Space) && myRigidbody.linearVelocityY > 0f)
        {
            inJump = true;
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocityX, myRigidbody.linearVelocityY * 0.5f); 

            coyoteTimeCounter = 0f;

            StartCoroutine(WaitUntilLand());

        }
        if(isGrounded())
        {
            inJump = false;
        }

        //if on this frame is not grounded, execute coroutine
        
    }



    IEnumerator WaitUntilLand()
    {
        yield return new WaitUntil(() => isGrounded());

        if(!landSound)
        {
            AkSoundEngine.PostEvent("octo_land", sfxObj);
            landSound = true;
        }
        
        
    }
    private void Dashing() //Dashing
    {
        if (Input.GetKeyDown (KeyCode.LeftShift) && canDash)
        {
            AkSoundEngine.PostEvent("octo_dash", sfxObj);
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
        wasGrounded = true;
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
        animator.SetBool("AnimDashing", true);
        yield return new WaitForSeconds(dashTime);
        myRigidbody.gravityScale = originalGravity;
        isDashing = false;
        animator.SetBool("AnimDashing", false);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}