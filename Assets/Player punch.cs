using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 10f;
    public float timeBetweenShots = 0.5f;
    public float projectileLifetime = 3f; 

    private float timer = 0f;
    private Vector2 lastInputDirection = Vector2.right; 

    void Update()
    {
        timer += Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0f || vertical != 0f)
        {
            lastInputDirection = new Vector2(horizontal, vertical).normalized;
        }

        if (Input.GetKeyDown(KeyCode.Space) && timer >= timeBetweenShots)
        {
            Shoot();
            timer = 0f; 
        }
    }

    void Shoot()
    {
        float angle = Mathf.Atan2(lastInputDirection.y, lastInputDirection.x) * Mathf.Rad2Deg;

        Vector2 spawnOffset = lastInputDirection * 0.5f; 

        Vector2 spawnPosition = (Vector2)shootPoint.position + spawnOffset;

        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.Euler(0f, 0f, angle));

        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        if (projectileRb != null)
        {
            lastInputDirection.Normalize();
            projectileRb.AddForce(lastInputDirection * shootForce, ForceMode2D.Impulse);
        }

        Destroy(projectile, projectileLifetime);

    }
}
