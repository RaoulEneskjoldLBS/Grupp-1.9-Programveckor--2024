using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class playermovment : MonoBehaviour
{
    //Stamina
    public UnityEngine.UI.Image Stamina_Bar;
    public float Stamina = 100, maxStamina = 100;
    public float attackCost = 10;
    public float runCost = 5;
    public float chargeRate = 33;
    private Coroutine recharge;
    private Rigidbody2D rb;
    public float dodgeCost = 20;

    //Movement
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public bool Sprinting;
    
    //Dodge
    public float dodgeSpeed = 10f;
    public float dodgeDuration = 0.5f;
    public KeyCode dodgeKey = KeyCode.Mouse1;
    public bool isDodging = false;



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

        
            Stamina -= runCost * Time.deltaTime;
            if (Stamina < 0) Stamina = 0;
            Stamina_Bar.fillAmount = Stamina / maxStamina;
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
        if (Input.GetKeyDown(KeyCode.Space) && Stamina > 0)
        {
            Stamina -= attackCost;
            if (Stamina <= 0) Stamina = 0;
            Stamina_Bar.fillAmount = Stamina / maxStamina;

            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(ChargeStamina());
        }

        //Dodgeing
            if (Input.GetKeyDown(dodgeKey) && !isDodging && Stamina > 0)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");
                Vector2 dodgeDirection = new Vector2(horizontalInput, verticalInput).normalized;

                StartCoroutine(PerformDodge(dodgeDirection));

                Stamina -= dodgeCost;
                if (Stamina <= 0) Stamina = 0;
                Stamina_Bar.fillAmount = Stamina / maxStamina;

                if (recharge != null) StopCoroutine(recharge);
               recharge = StartCoroutine(ChargeStamina());
            }
        
    }

    IEnumerator PerformDodge(Vector2 dodgeDirection)
    {

        isDodging = true;

        Vector2 dodgeEndpoint = (Vector2)transform.position + dodgeDirection * dodgeSpeed * dodgeDuration;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        float startTime = Time.time;
        while (Time.time - startTime < dodgeDuration)
        {
            rb.MovePosition(Vector2.Lerp(transform.position, dodgeEndpoint, (Time.time - startTime) / dodgeDuration));
            yield return null;
        }

        isDodging = false;
    }

    //Stamina Recharge
    private IEnumerator ChargeStamina()
    {
        yield return new WaitForSeconds(2f);
        while(Stamina < maxStamina)
        {
            Stamina += chargeRate / 10f;
            if (Stamina > maxStamina) Stamina = maxStamina;
            Stamina_Bar.fillAmount = Stamina / maxStamina;
            yield return new WaitForSeconds(.1f);

            
        }
    }
    
    

    
}

