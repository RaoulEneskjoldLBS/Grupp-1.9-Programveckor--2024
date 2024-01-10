using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 10f;
    public float timeBetweenShots = 0.5f;
    public float projectileLifetime = 5f;
    private float timer = 0f;

    void Update()
    {
       
        timer += Time.deltaTime;

        
        if (Input.GetKey(KeyCode.Space) && timer >= timeBetweenShots)
        {
          
            Shoot();
            timer = 0f; 
        }
    }

    void Shoot()
    {

      
        Quaternion playerRotation = transform.rotation;

       
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, playerRotation);

      
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        if (projectileRb != null)
        {
            projectileRb.AddForce(shootPoint.right * shootForce, ForceMode2D.Impulse);
        }

        Destroy(projectile, projectileLifetime);
    }
}
