

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f;
    public float initialDetectionRange = 10f;
    private float currentDetectionRange;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        currentDetectionRange = initialDetectionRange;
    }

    void Update()
    {
        
        if (Vector2.Distance(transform.position, player.position) < currentDetectionRange)
        {
            
            Vector2 direction = player.position - transform.position;
            rb.velocity = direction.normalized * speed;

            
            currentDetectionRange = 10000f;
        }
        else
        {
            
            rb.velocity = Vector2.zero;
        }
    }
}
