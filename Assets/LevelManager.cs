using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float levelTime = 30f;   // ��� ����� ����
    public Text timerText;          // ����� ����� �� ����

    private float remainingTime;

    private void Start()
    {
        remainingTime = levelTime;  // ����� ����
    }

    private void Update()
    {
        // ����� ��� ����
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            Debug.Log("Time's up! Restarting level...");
            ReloadCurrentLevel();  // ��� ���� �� ���� ����
        }
    }

    // ����� ���� ���
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

    // ����� ���� ������ ����
    public void ReloadCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // ����� ���� ������ �� ������
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time: {Mathf.Ceil(remainingTime)}s";
        }
    }
}
