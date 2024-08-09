using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;



public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance

    public TextMeshProUGUI scoreText;

    public static int scoreCount;

    private void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this instance across scene loads
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    private void Start()
    {
        // Initialize the score UI
        UpdateUI();
    }

    private void Update()
    {
        // Continuously update the UI
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + scoreCount;
        }

        // Check for game restart condition
        if (scoreCount >= 12)
        {
            // Reset the score before restarting
            ResetScore();
            RestartGame();
        }
    }

    public void AddScore(int value)
    {
        scoreCount += value;
        UpdateUI();
    }

    public void ResetScore()
    {
        scoreCount = 0;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}

