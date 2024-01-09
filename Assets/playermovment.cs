using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{


    Rigidbody2D playerrigidbody;



    // Start is called before the first frame update
     void Start()
    {
        playerrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            playerrigidbody.AddForce(new Vector2(1, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerrigidbody.AddForce(new Vector2(-1, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerrigidbody.AddForce(new Vector2(0, 1));
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerrigidbody.AddForce(new Vector2(0, -1));
        }
    }
}
