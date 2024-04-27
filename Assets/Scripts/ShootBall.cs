using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public float shootForce = 10f;
    public float destroyDelay = 5f;
    public float distance = 1;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the input you want to use for shooting
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the ball prefab
        Vector3 offset = transform.forward * distance; // Adjust 'distance' as needed
        GameObject ball = Instantiate(ballPrefab, transform.position + offset, Quaternion.identity);
        
        // Get the main camera's forward direction and apply force in that direction
        Vector3 shootDirection = Camera.main.transform.forward;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        GetComponent<Health>().health--;
        // Destroy the ball after a delay
        Destroy(ball, destroyDelay);
    }
}
