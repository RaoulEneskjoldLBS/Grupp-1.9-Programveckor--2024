using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class EnemyAI : MonoBehaviour

{
    public float speed = 5f;
    public float detectionRange = 10f;
    private Transform player;
    private Rigidbody2D rb;

    void Start()

    {
       // player = GameObject.FindGameObjectWithTag("Player").transform;

        //rb = GetComponent<Rigidbody2D>();
    }
    void Update()

    {

       // if (Vector2.Distance(transform.position, player.position) < detectionRange)

        //{
           // Vector2 direction = player.position - transform.position;
            //rb.velocity = direction.normalized * speed;
       // }
       // else

       // {
            //rb.velocity = Vector2.zero;
       // }
        void Start()

        {
            //player = GameObject.FindGameObjectWithTag("Player").transform;

           // rb = GetComponent<Rigidbody2D>();
        }

    }

}

