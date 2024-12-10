using UnityEngine;
using TMPro;

public class MagneticTarget : MonoBehaviour
{
    public GameObject hitEffect;          // Particle effect
    public TextMeshProUGUI gameCompleteText;  // "Game Complete" text
    public LevelManager levelManager;     // Reference to LevelManager
    public float delayBeforeEnd = 2f;     // Delay before ending the game

    private bool isGameCompleted = false;  // Prevent multiple triggers

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetBall") && !isGameCompleted)
        {
            Debug.Log("Magnet Ball Hit the Final Target!");
            isGameCompleted = true;

            // Trigger the particle effect
            Instantiate(hitEffect, transform.position, Quaternion.identity);

            // Show "Game Complete!" text
            gameCompleteText.gameObject.SetActive(true);

            // End the game after a delay
            Invoke(nameof(EndGame), delayBeforeEnd);
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Completed! Exiting...");
        Application.Quit();  // Works only in builds
    }
}
