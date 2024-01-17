using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OHSHITARAT : MonoBehaviour


 
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;

    Animator animator;

    SpriteRenderer sr;

    playermovment Player;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

   

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);


        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();


        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;


        rb.velocity = new Vector2(movement.x * currentSpeed, movement.y * currentSpeed);
        float horizontalmove = Input.GetAxisRaw("Horizontal") * currentSpeed;
        float verticalmove = Input.GetAxisRaw("Vertical") * currentSpeed;

        if (horizontalmove < -0.1)
        {
            sr.flipX = true;
        }
        else if (horizontalmove > 0.1)
        {
            sr.flipX = false;
        }

        if (horizontalmove >= 0.1 )
        {
            animator.SetBool("RAT RIGHT", true);
        }

        if (horizontalmove < 0.1 )
        {
            animator.SetBool("RAT RIGHT", false);
        }

        if (horizontalmove <= -0.1 )
        {
            animator.SetBool("RAT LEFT", true);
        }

        if (horizontalmove > -0.1 )
        {
            animator.SetBool("RAT LEFT", false);
        }

        if (verticalmove >= 0.1 )
        {
            animator.SetBool("RAT UP", true);
        }

        if (verticalmove < 0.1 )
        {
            animator.SetBool("RAT UP", false);
        }

        if (verticalmove <= -0.1)
        {
            animator.SetBool("RAT DOWN", true);
        }

        if (verticalmove > -0.1)
        {
            animator.SetBool("RAT DOWN", false);
        }
    }
}
