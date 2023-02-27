using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;
    Rigidbody2D body;
    Animator anim;
    bool isJumping = false;
    [SerializeField]
    float jumpForce = 4;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Jumping();
    }

    void PlayerMovement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(Vector2.right.x * (moveSpeed * h), body.velocity.y);
        body.velocity = velocity;

        anim.SetFloat("Speed", velocity.x);

        if (velocity.x < 0)
        {
            anim.transform.localScale = new Vector3(-1, 1, 1);
            body.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (velocity.x > 0)
        {

            body.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Jumping()
    {
        if (isJumping)
        {
            if (body.velocity.y == 0)
            {
                isJumping = false;
                anim.SetBool("isJumping", false);
            }
        }
        else
        {
            if (Input.GetAxis("Jump") > 0)
            {
                body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                anim.SetBool("isJumping", true);
            }
        }
    }
}
