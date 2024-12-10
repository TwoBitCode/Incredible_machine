using UnityEngine;
using TMPro;

public class MagneticTarget : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject hitEffect;              // Particle effect
    public GameObject gameCompletePanel;      // Game complete screen
    public TextMeshProUGUI gameCompleteText;  // Completion message

    [Header("Level Manager Reference")]
    public LevelManager levelManager;         // Reference to the LevelManager

    [Header("Game Settings")]
    [SerializeField] private float delayBeforeMessage = 2f; // Delay before showing the message

    // Prevent multiple triggers
    private bool isGameCompleted = false;

    // Constant to define the expected tag
    private const string MagnetBallTag = "MagnetBall";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(MagnetBallTag) && !isGameCompleted)
        {
            Debug.Log("Magnet Ball Hit the Final Target!");
            isGameCompleted = true;

            // Stop the timer in LevelManager
            levelManager.CompleteLevel();

            // Trigger the particle effect
            Instantiate(hitEffect, transform.position, Quaternion.identity);

            // Display "Game Complete!" message after delay
            Invoke(nameof(ShowEndScreen), delayBeforeMessage);
        }
    }

    private void ShowEndScreen()
    {
        Debug.Log("Congratulations! You Completed the Game!");
        gameCompletePanel.SetActive(true);
        gameCompleteText.text = "Congratulations! You Completed the Game!";
    }
}
