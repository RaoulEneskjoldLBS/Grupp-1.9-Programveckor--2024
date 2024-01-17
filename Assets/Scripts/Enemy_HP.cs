using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public Playerpunch PP;


    public float Enemy_Health_Ammount = 100;
    public GameObject Enemy;
    public Rigidbody2D E_rb;
    



    void Start()
    {
        Enemy_Health_Ammount = 100;
        E_rb = GetComponent<Rigidbody2D>();
        PP = FindObjectOfType<Playerpunch>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "FIst") //Change "Player" to "Projectile" when projectile object exists
        {
            Enemy_Take_Damage(PP.dmg);
        }
    }

    void Update()
    {
        
        if(Enemy_Health_Ammount <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void Enemy_Take_Damage(float Damage)
    {
        Enemy_Health_Ammount -= Damage;
    }
}
