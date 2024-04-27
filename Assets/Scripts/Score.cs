using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{
    // Public variables
    public TextMeshProUGUI  scoreText;
    
    // Private variables
    public float scoreValue = 0;

    // Property for accessing and updating score

    private void Start()
    {
        // Load score from PlayerPrefs
        //scoreValue = PlayerPrefs.GetInt("Score", 0);
        PlayerPrefs.SetInt("Score", 0);
        UpdateScoreText();
    }


    void Update()
    {
        // Load score from PlayerPrefs
        scoreValue += (1f * Time.deltaTime);
        PlayerPrefs.SetInt("Score", (int) scoreValue);
        UpdateScoreText();
    }

    // Update the score text UI
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + (int) scoreValue;
    }

    // Update PlayerPrefs with the new score
    public void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetInt("Score", (int) scoreValue);
        PlayerPrefs.Save();
    }
}
