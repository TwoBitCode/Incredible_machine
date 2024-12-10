using UnityEngine;
using TMPro;

public class MagneticTarget : MonoBehaviour
{
    public GameObject hitEffect; // Particle effect
    public TextMeshProUGUI levelCompleteText; // UI Text

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetBall")) // Check for MagneticBall
        {
            Debug.Log("Magnetic Ball Reached the Target!");

            // Activate the particle effect
            Instantiate(hitEffect, transform.position, Quaternion.identity);

            // Display Level Complete UI
            levelCompleteText.gameObject.SetActive(true);
        }
    }
}
