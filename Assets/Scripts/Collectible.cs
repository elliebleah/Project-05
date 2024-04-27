using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Reference to the Score component
    public Score scoreManager;
    public int value;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Increment the score
            scoreManager.scoreValue += value;
            scoreManager.UpdateScoreText();

            // Disable the collectible object
            gameObject.SetActive(false);
        }
    }
}
