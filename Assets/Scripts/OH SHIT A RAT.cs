using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OHSHITARAT : MonoBehaviour


 
{
    public float moveSpeed = 4f;
    

    Animator animatorr;

    SpriteRenderer srr;

    

    private Rigidbody2D rbb;
    // Start is called before the first frame update
    void Start()
    {
        animatorr = GetComponent<Animator>();
        srr = GetComponent<SpriteRenderer>();
        rbb = GetComponent<Rigidbody2D>();
    }

   

    // Update is called once per frame
    void Update()
    {

        float ratspeed = moveSpeed;

        float horizontalnew = Input.GetAxisRaw("Horizontal")* ratspeed;
        float verticalnew = Input.GetAxisRaw("Vertical") * ratspeed;
       
       
       

        if (horizontalnew >= 0.1 )
        {
            animatorr.SetBool("RAT RIGHT", true);
        }

        if (horizontalnew < 0.1 )
        {
            animatorr.SetBool("RAT RIGHT", false);
        }

        if (horizontalnew <= -0.1 )
        {
            animatorr.SetBool("RAT LEFT", true);
        }

        if (horizontalnew > -0.1 )
        {
            animatorr.SetBool("RAT LEFT", false);
        }

        if (verticalnew >= 0.1 )
        {
            animatorr.SetBool("RAT UP", true);
        }

        if (verticalnew < 0.1 )
        {
            animatorr.SetBool("RAT UP", false);
        }

        if (verticalnew <= -0.1)
        {
            animatorr.SetBool("RAT DOWN", true);
        }

        if (verticalnew > -0.1)
        {
            animatorr.SetBool("RAT DOWN", false);
        }
        if (horizontalnew < -0.1)
        {
            srr.flipX = true;
        }
        else if (horizontalnew > 0.1)
        {
            srr.flipX = false;
        }
    }
}
