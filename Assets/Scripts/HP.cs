using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Image HealthBar;
    public float Health_ammount = 100;
    public GameObject Player;
    public Rigidbody2D rB;

    

    private void Start()
    {
        Health_ammount = 100;
        rB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }
    }

    private void Update()
    {
        if (Health_ammount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }



        
          
        
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            Healing(10);
        }
    }

    

    public void TakeDamage(float Damage)
    {
        
        Health_ammount -= Damage;
        HealthBar.fillAmount = Health_ammount / 100;

    }

    public void Healing(float healthpoints)
    {
        Health_ammount += healthpoints;
        Health_ammount = Mathf.Clamp(Health_ammount, 0, 100);

        HealthBar.fillAmount = Health_ammount / 100;
    }
        

}
