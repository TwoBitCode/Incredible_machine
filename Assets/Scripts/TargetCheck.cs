using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public GameObject hitEffectPrefab;      // Drag the HitEffect prefab here
    public TextMeshProUGUI levelCompleteText;  // Assign the TextMeshPro object here
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))   // Check if the correct ball hit the target
        {
            Debug.Log("Target Hit! Level Complete!");

            // Trigger the particle effect
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

            // Show "Level Complete" text
            if (levelCompleteText != null)
            {
                levelCompleteText.gameObject.SetActive(true);
            }

            // Progress to the next level
            levelManager.LoadNextLevel();
        }
    }
}
