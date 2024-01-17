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
       

       

        if (horizontal >= 0.1 )
        {
            animator.SetBool("RAT RIGHT", true);
        }

        if (horizontal < 0.1 )
        {
            animator.SetBool("RAT RIGHT", false);
        }

        if (horizontal <= -0.1 )
        {
            animator.SetBool("RAT LEFT", true);
        }

        if (horizontal > -0.1 )
        {
            animator.SetBool("RAT LEFT", false);
        }

        if (vertical >= 0.1 )
        {
            animator.SetBool("RAT UP", true);
        }

        if (vertical < 0.1 )
        {
            animator.SetBool("RAT UP", false);
        }

        if (vertical <= -0.1)
        {
            animator.SetBool("RAT DOWN", true);
        }

        if (vertical > -0.1)
        {
            animator.SetBool("RAT DOWN", false);
        }
        if (horizontal < -0.1)
        {
            sr.flipX = true;
        }
        else if (horizontal > 0.1)
        {
            sr.flipX = false;
        }
    }
}
