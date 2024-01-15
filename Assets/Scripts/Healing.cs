using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    public Image HealthBar;
    public float Health_amount = 100;
    public GameObject Player;
    public Rigidbody2D rB;


    private void Start()
    {
        Health_amount = 100;
        rB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Healing")
        {
            Heal(20);
        }
    }





    public void Heal(float healthpoints)
    {
        Health_amount += healthpoints;
        Health_amount = Mathf.Clamp(Health_amount, 0, 100);

        HealthBar.fillAmount = Health_amount / 100;
    }
}
