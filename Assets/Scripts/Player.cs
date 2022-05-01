using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public BoxCollider2D Floor;
    public bool DoubleJump;
    // Start is called before the first frame update
    void Start()
    {
        DoubleJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // Jumping Action 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GetComponent<CircleCollider2D>().IsTouching(Floor))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                DoubleJump = false;
            }
            else
            {
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
        }

        // Moving Left Action
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent <Rigidbody2D>().AddForce(Vector2.left * 4, ForceMode2D.Force);
        }
    }
}
