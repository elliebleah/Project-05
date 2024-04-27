using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyScript : MonoBehaviour
{
    public Transform player;
    public float followDistance = 10f; // Distance at which the enemy starts following the player
    public float moveSpeed = 3.5f;

    private NavMeshAgent navMeshAgent;

    [SerializeField] Vector3 transformReset;

    [SerializeField] bool hurtingPlayer = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if the player is within the follow distance
        if (player != null)
        {
            // Set the destination for the NavMeshAgent to follow the player
            navMeshAgent.SetDestination(player.position);
        }
        if (player == null)
        {
            // Stop moving if the player is out of range
            navMeshAgent.SetDestination(transform.position);
        }
        if (hurtingPlayer && player != null)
        {
            player.GetComponent<Health>().health -= 1 * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other.CompareTag("Player"))
        {
            // Get the Health component from the player
            Debug.Log("Colliding with enemy");
            Health playerHealth = other.GetComponent<Health>();

            // If the Health component exists, start reducing health
            if (playerHealth != null)
            {
                hurtingPlayer = true;
                
            }
        }
        if (other.CompareTag("Ball"))
        {
            ResetPos();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collided object is the player
        Debug.Log("Not Colliding with enemy");
        if (other.CompareTag("Player"))
        {
            hurtingPlayer = false;
        
        }
        
    }

    
    void ResetPos()
    {
        this.transform.position = transformReset;
    }
}