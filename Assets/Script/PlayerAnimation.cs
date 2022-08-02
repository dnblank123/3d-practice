using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    int isRunHash;
    int isRunBackHash;

    int isRunLeftHash;
    int isRunRightHash;
    int isJumpHash;
    int isAttackHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunHash = Animator.StringToHash("isRun");
        isRunBackHash = Animator.StringToHash("isRunBack");
        isRunLeftHash = Animator.StringToHash("isRunLeft");
        isRunRightHash = Animator.StringToHash("isRunRight");
        isJumpHash = Animator.StringToHash("isJump");
        isAttackHash = Animator.StringToHash("isAttack");

    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimate();

    }

    private void PlayerAnimate()
    {
        bool isRun = animator.GetBool(isRunHash);
        bool isRunBack = animator.GetBool(isRunBackHash);
        bool isRunLeft = animator.GetBool(isRunLeftHash);
        bool isRunRight = animator.GetBool(isRunRightHash);
        bool isJump = animator.GetBool(isJumpHash);
        bool isAttack = animator.GetBool(isAttackHash);


        bool ForwardRun = Input.GetKey("w");
        bool BackRun = Input.GetKey("s");
        bool LeftRun = Input.GetKey("a");
        bool RightRun = Input.GetKey("d");
        bool Jumped = Input.GetKey("space");
        bool Attack = Input.GetMouseButton(0);


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
        //back to idle
        if(isRunBack && !BackRun)
        {
            animator.SetBool("isRunBack", false);

        }
        //left
        if(!isRunLeft && LeftRun)
        {
            animator.SetBool("isRunLeft", true);
        }
        //back to idle
        if(isRunLeft && !LeftRun)
        {
            animator.SetBool("isRunLeft", false);

        }
        // right
        if(!isRunRight && RightRun)
        {
            animator.SetBool("isRunRight", true);

        }
        //back to idle
        if(isRunRight && !RightRun)
        {
            animator.SetBool("isRunRight", false);
        }
        //jump
        if(!isJump && Jumped)
        {
            animator.SetBool("isJump", true);
        }
        if(isJump && !Jumped)
        {
            animator.SetBool("isJump", false);
        }
        if(!isAttack && Attack)
        {
            animator.SetBool("isAttack", true);

        }
        if(isAttack && !Attack)
        {
            animator.SetBool("isAttack", false);

        }

    }
}
