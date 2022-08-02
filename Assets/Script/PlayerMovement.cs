using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask IsGround;
    bool grounded;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;


    Vector3 moveDirection;

    Rigidbody rb;
    //animation
    private Animator animator;
    int isRunHash;
    int isRunBackHash;

    int isRunLeftHash;
    int isRunRightHash;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ResetJump();

        //animation
        animator = GetComponent<Animator>();
        isRunHash = Animator.StringToHash("isRun");
        isRunBackHash = Animator.StringToHash("isRunBack");
        isRunLeftHash = Animator.StringToHash("isRunLeft");
        isRunRightHash = Animator.StringToHash("isRunRight");

    }

    private void Update() 
    {
        //Debug.Log(grounded);
        grounded = Physics.CheckSphere(transform.position, playerHeight * 0.5f + 0.2f, IsGround);
        MovePlayer();
        MyInput();
        SpeedControl();

        if(grounded){

            rb.drag = groundDrag;  
              
        } else {

            rb.drag = 0;
        } 
    } 
    private void MyInput() 
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        bool isRun = animator.GetBool(isRunHash);
        bool isRunBack = animator.GetBool(isRunBackHash);
        bool isRunLeft = animator.GetBool(isRunLeftHash);
        bool isRunRight = animator.GetBool(isRunRightHash);


        bool ForwardRun = Input.GetKey("w");
        bool BackRun = Input.GetKey("s");
        bool LeftRun = Input.GetKey("a");
        bool RightRun = Input.GetKey("d");        

        //forward 
        if(!isRun && ForwardRun)
        {
            animator.SetBool("isRun", true);
        }
        //back to idle
        if(isRun && !ForwardRun)
        {
            animator.SetBool("isRun", false);

        }
        //back
        if(!isRunBack && BackRun)
        {
            animator.SetBool("isRunBack", true);

        }
        if(isRunBack && !BackRun)
        {
            animator.SetBool("isRunBack", false);

        }
        //left
        if(!isRunLeft && LeftRun)
        {
            animator.SetBool("isRunLeft", true);
        }

        if(isRunLeft && !LeftRun)
        {
            animator.SetBool("isRunLeft", false);

        }
        // right
        if(!isRunRight && RightRun)
        {
            animator.SetBool("isRunRight", true);

        }
        if(isRunRight && !RightRun)
        {
            animator.SetBool("isRunRight", false);

        }


        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
            
        }
    }
    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(moveDirection.x == horizontalInput)
        {
            
        }
        
        //on ground
        if(grounded)

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded) 
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        
        
    }
    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVelocity.magnitude > moveSpeed){

            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);

        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
    private void OnCollisionEnter(Collision other) 
    {
      if(other.gameObject.tag == "Ship")
      {
            ResetJump();
      }

    }
    

}
