using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saves : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    private Rigidbody2D rb;

    Animator animator;

    SpriteRenderer sr;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);


        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();


        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;


        rb.velocity = new Vector2(movement.x * currentSpeed, movement.y * currentSpeed);


        float horizontalmove = Input.GetAxisRaw("Horizontal") * currentSpeed;

        animator.SetFloat("run", Mathf.Abs(horizontalmove));


        if (horizontalmove >= 1 && Input.GetKeyDown(KeyCode.D))
        { 
            animator.SetBool("D", true);
        }
        
        if (horizontalmove < 1 && Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("D", false);
        }

        if (horizontalmove < 0)
        {
            sr.flipX = true;
        } else
        {
            sr.flipX = false;
        }
        if (horizontalmove <= -1 && Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("A", true);
        }

        if (horizontalmove > -1 && Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("A", false);
        }


        float verticalmove = Input.GetAxisRaw("Vertical") * currentSpeed;

        animator.SetFloat("runv", Mathf.Abs(verticalmove));

        if (verticalmove >= 1 && Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("W", true);
        }

        if (verticalmove < 1 && Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("W", false);
        }

        if (verticalmove <= -1 && Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("S", true);
        }

        if (verticalmove > -1 && Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("S", false);
        } 

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetBool("Dodge", true);

        } else
        {
            animator.SetBool("Dodge", false);
        }
    }
}
