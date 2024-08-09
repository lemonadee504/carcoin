using System.Collections;
using UnityEngine;
using TMPro;

public class GameeManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;   // Reference to the game over UI text
    public TextMeshProUGUI timerText;      // Reference to the timer UI text

    public int score = 0;
    public float timeRemaining = 60f;
    public bool isGameOver = false;

    private void Start()
    {
        // Ensure normal time scale
        Time.timeScale = 1f;

        // Initialize the UI elements
        gameOverText.gameObject.SetActive(false);
        UpdateScoreText();
        UpdateTimerText();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            // Update the timer
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                EndGame();
            }
        }
    }

    // Call this method to add score
    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateScoreText();
        }
    }

    // Update the score UI
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Update the timer UI
    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
    }

    // Trigger game over
    private void EndGame()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "GameOver!";
    }
}
