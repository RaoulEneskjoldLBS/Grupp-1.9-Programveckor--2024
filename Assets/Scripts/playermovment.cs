using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playermovment : MonoBehaviour
{

 
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
       
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);



 
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

      
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        
        rb.velocity = new Vector2(movement.x * currentSpeed, movement.y * currentSpeed);

    }

    
 
}

