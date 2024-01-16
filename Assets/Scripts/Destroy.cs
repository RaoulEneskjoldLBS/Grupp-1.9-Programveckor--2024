using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject Healing_item;
    public Rigidbody2D Hrb;

    public void Start()
    {
        Hrb = GetComponent<Rigidbody2D>();
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
