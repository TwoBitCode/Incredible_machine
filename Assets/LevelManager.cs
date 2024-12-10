using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float levelTime = 30f;                // Time allocated per level
    public TextMeshProUGUI timerText;            // Timer display
    private float remainingTime;
    private bool isLevelCompleted = false;      // Prevents double triggers

    private void Start()
    {
        remainingTime = levelTime;               // Initialize timer
    }

    private void Update()
    {
        if (!isLevelCompleted)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                Debug.Log("Time's up! Restarting level...");
                ReloadCurrentLevel();  // If time runs out
            }
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
