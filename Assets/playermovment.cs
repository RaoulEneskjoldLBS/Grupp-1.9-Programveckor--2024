using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playermovment : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       
        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        

        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
