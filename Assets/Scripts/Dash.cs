using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    public float dodgeSpeed = 10f;
    public float dodgeDuration = 0.5f;
    public KeyCode dodgeKey = KeyCode.Mouse1;

    private bool isDodging = false;

    void Update()
    {
        if (Input.GetKeyDown(dodgeKey) && !isDodging)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 dodgeDirection = new Vector2(horizontalInput, verticalInput).normalized;

            StartCoroutine(PerformDodge(dodgeDirection));
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
}