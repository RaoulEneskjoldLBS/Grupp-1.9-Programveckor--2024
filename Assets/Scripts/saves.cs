using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saves : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float punchForce = 10f;
    private Rigidbody2D rb;

    Animator animator;

    SpriteRenderer sr;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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
    }
}
