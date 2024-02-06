using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public Playerpunch PP;


    public float enemyHealthAmmount = 100;
    public GameObject Enemy;
    public Rigidbody2D enemyRB;
    


   


    void Start()
    {
        enemyHealthAmmount = 20;
        enemyRB = GetComponent<Rigidbody2D>();
        PP = FindObjectOfType<Playerpunch>();
    }

    //Enemy takes damage
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "FIst") //Change "Player" to "Projectile" when projectile object exists
        {
            Enemy_Take_Damage(PP.dmg);
        }
    }

    void Update()
    {
        //Enemy death
        if(enemyHealthAmmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Enemy_Take_Damage(float Damage)
    {
        enemyHealthAmmount -= Damage;
    }
}
