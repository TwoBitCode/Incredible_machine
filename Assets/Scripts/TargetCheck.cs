using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public GameObject hitEffectPrefab; // Drag the HitEffect prefab here
    public TextMeshProUGUI levelCompleteText; // Assign the TextMeshPro object here

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Debug.Log("Target Hit! Level Complete!");

            // Instantiate the particle effect at the target's position
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

            // Show "Level Complete!" text
            if (levelCompleteText != null)
            {
                levelCompleteText.gameObject.SetActive(true);
            }
        }
    }
}
