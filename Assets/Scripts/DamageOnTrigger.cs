using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    public float damagePerSecond = 1f; // Amount of damage per second

    // Called when a Collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Start applying damage over time
            Debug.Log("Enter Trigger");
            ApplyDamageOverTime(other.gameObject);
        }
    }

    // Called when a Collider exits the trigger
    void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Stop applying damage over time
            Debug.Log("Exit Trigger");
            StopDamageOverTime(other.gameObject);
        }
    }

    // Coroutine to apply damage over time
    void ApplyDamageOverTime(GameObject player)
    {
        // Start a coroutine to apply damage over time
        StartCoroutine(DamageCoroutine(player));
    }

    // Coroutine to stop damage over time
    void StopDamageOverTime(GameObject player)
    {
        // Stop the coroutine if it's currently running
        StopCoroutine(DamageCoroutine(player));
    }

    // Coroutine that applies damage over time
    IEnumerator DamageCoroutine(GameObject player)
    {
        Health health = player.GetComponent<Health>();
        // Get the Health component from the player

        // Loop infinitely until the trigger is exited
        while (true)
        {
            // Reduce the player's health by damagePerSecond each second
            health.health -= damagePerSecond;

            // Wait for 1 second before applying the next damage
            yield return new WaitForSeconds(1f);
        }
    }
}