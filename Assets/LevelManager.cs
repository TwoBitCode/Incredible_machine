using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float levelTime = 30f;              // Total time for the level
    public TextMeshProUGUI timerText;          // Timer display text

    private float remainingTime;
    private bool isLevelCompleted = false;      // Prevents timer from running after completion

    private void Start()
    {
        remainingTime = levelTime;            // Initialize timer
        UpdateTimerUI();                      // Show initial time
    }

    private void Update()
    {
        if (!isLevelCompleted && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (!isLevelCompleted && remainingTime <= 0)
        {
            Debug.Log("Time's up! Restarting level...");
            ReloadCurrentLevel();  // Restart if time runs out
        }
    }

    // **ADD THIS METHOD** to stop the timer when the level is completed
    public void CompleteLevel()
    {
        if (!isLevelCompleted)
        {
            Debug.Log("Level Completed!");
            isLevelCompleted = true;  // Stop the timer
        }
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);  // Load the next level
        }
        else
        {
            Debug.Log("All levels completed!");
            EndGame();  // If it's the last level
        }
    }

    public void ReloadCurrentLevel()
    {
        if (!isLevelCompleted)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);  // Reload current level
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Completed! Exiting...");
        Application.Quit();  // Works in builds only
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time: {Mathf.Ceil(remainingTime)}s";
        }
    }
}
