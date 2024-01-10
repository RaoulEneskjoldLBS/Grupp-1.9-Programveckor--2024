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

        // Get input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        movement.Normalize(); // Normalize to ensure diagonal movement is not faster

        // Move the player directly by manipulating the position
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
