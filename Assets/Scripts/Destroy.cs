using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject healingItem;
    public Rigidbody2D healingRigidBody;

    public void Start()
    {
        healingRigidBody = GetComponent<Rigidbody2D>();
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
