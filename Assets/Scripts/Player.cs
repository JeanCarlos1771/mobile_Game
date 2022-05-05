using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public BoxCollider2D Floor;
    private bool DoubleJump;
    public ParticleSystem Jump_Effect;
    private bool looking_right;
    public Animator animator;
    private float IsMoving;
    private float RunSpeed;
    private bool JumpAnimation;

    // Start is called before the first frame update
    void Start()
    {
        DoubleJump = false;
        looking_right = true;
        JumpAnimation = false;
        IsMoving = 0f;
        RunSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        IsMoving = Input.GetAxisRaw("Horizontal") * RunSpeed;
        animations();

    }

    void PlayerMovement()
    {
        var Jump_main = Jump_Effect.main;

        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            JumpAnimation = false;
        }

        // Jumping Action 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GetComponent<BoxCollider2D>().IsTouching(Floor))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                SetDustEffect();

                JumpAnimation = true;
                DoubleJump = false;
            }
            else
            {
                // Performing a double Jump 
                if(DoubleJump == false)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    DoubleJump = true;
                }
            }
        }

        // Moving Right Action
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4, ForceMode2D.Force);
            if (looking_right == false)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                SetDustEffect();
                looking_right = true;
            }
        }

        // Moving Left Action
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent <Rigidbody2D>().AddForce(Vector2.left * 4, ForceMode2D.Force);
            if (looking_right != false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                SetDustEffect();
                looking_right = false;
            }
        }
    }

    // Method to create dust effect whenever the player moves or jumps
    void SetDustEffect()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(Floor))
        {
            Jump_Effect.Play();
        }else
        {
            Jump_Effect.Stop();
        }
    }

    // Method to call Animation Loops in unity.
    void animations()
    {
        animator.SetFloat("Movement", Mathf.Abs(IsMoving));

        animator.SetBool("IsJumping", JumpAnimation);

    }
}