using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Retrieve the score from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);

        // Update the text with the score
        scoreText.text = "Your score was: " + score.ToString();
    }
}
