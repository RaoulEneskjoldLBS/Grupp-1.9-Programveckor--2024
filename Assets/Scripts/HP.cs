using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public Image healthBarBackground;
    public float healthAmmount = 100;
    public GameObject Player;
    public Rigidbody2D rB;

    

    private void Start()
    {
        healthAmmount = 100;
        rB = GetComponent<Rigidbody2D>();
    }

    //Checks what object player collides with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
        }
        else if(collision.gameObject.tag == "Healing")
        {
            Heal(20);
        }
    }

    //Death when HP = 0
    private void Update()
    {
        if (healthAmmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
   
        
    }

    
    //Damage
    public void TakeDamage(float Damage)
    {
        
        healthAmmount -= Damage;      
        healthBar.fillAmount = healthAmmount / 100;

    }

    //Healing
    public void Heal(float health_points)
    {
        healthAmmount += health_points;
        healthAmmount = Mathf.Clamp(healthAmmount, 0, 100);

        healthBar.fillAmount = healthAmmount / 100;
    }

   


}
