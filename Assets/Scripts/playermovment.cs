using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class playermovment : MonoBehaviour
{

    public UnityEngine.UI.Image Stamina_Bar;
    public float Stamina = 100, Max_Stamina = 100;
    public float Attack_Cost = 10;
    public float Run_Cost;

    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public bool Sprinting;

    public float ChargeRate = 33;

    private Coroutine recharge;
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprinting = false;
    }

    void Update()
    {
       
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        //If Sprint is True/False
        if (Input.GetKeyDown(KeyCode.LeftShift) && Stamina > 0)
        {
            Sprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Stamina <= 0)
        {
            Sprinting = false;
        }

        //Stamina when moving
        if (Sprinting && (movement.x != 0 || movement.y != 0))
        {

        
            Stamina -= Run_Cost * Time.deltaTime;
            if (Stamina < 0) Stamina = 0;
            Stamina_Bar.fillAmount = Stamina / Max_Stamina;
            if (Stamina < 0)
            {
                Sprinting = false;
                
            }

            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(ChargeStamina());

        }
        else

        {
            rb.velocity = movement * moveSpeed * 1;
        }
        

        //Stamina when attacking
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stamina -= Attack_Cost;
            if (Stamina < 0) Stamina = 0;
            Stamina_Bar.fillAmount = Stamina / Max_Stamina;

            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(ChargeStamina());
        }



        

    }
    
    //Stamina Recharge
    private IEnumerator ChargeStamina()
    {
        yield return new WaitForSeconds(1f);
        while(Stamina < Max_Stamina)
        {
            Stamina += ChargeRate / 10f;
            if (Stamina > Max_Stamina) Stamina = Max_Stamina;
            Stamina_Bar.fillAmount = Stamina / Max_Stamina;
            yield return new WaitForSeconds(.1f);
        }
    }
    

    
}

