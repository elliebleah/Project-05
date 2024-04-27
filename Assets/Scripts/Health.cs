using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health = 100f; // Initial health value
    public TextMeshProUGUI healthText; // Reference to the TextMeshPro UI component

    // Update is called once per frame
    void Update()
    {
        // Update the TextMeshPro UI component with the current health value
        healthText.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            // Set screen to GameOverScene
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOverScene");
        }
    }
}