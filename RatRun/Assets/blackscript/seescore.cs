using UnityEngine;
using UnityEngine.UI;

public class scoresystem : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private void Start()
    {
        // Initialize the score text
        UpdateScoreDisplay();
    }

    // Call this method to increase the score
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    // Update the score text on the UI
    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}