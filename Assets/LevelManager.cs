using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float levelTime = 30f;   // זמן מוקצב לשלב
    public Text timerText;          // תצוגת טיימר על המסך

    private float remainingTime;

    private void Start()
    {
        remainingTime = levelTime;  // אתחול הזמן
    }

    private void Update()
    {
        // עדכון זמן השלב
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            Debug.Log("Time's up! Restarting level...");
            ReloadCurrentLevel();  // טען מחדש אם הזמן נגמר
        }
    }

    // טעינת השלב הבא
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("All levels completed!");
        }
    }

    // טעינת השלב הנוכחי מחדש
    public void ReloadCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // עדכון ממשק המשתמש של הטיימר
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time: {Mathf.Ceil(remainingTime)}s";
        }
    }
}
