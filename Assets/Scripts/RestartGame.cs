using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(0);
        scoreManager.ResetScore();
    }
}
