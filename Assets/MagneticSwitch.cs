using UnityEngine;

public class MagneticSwitch : MonoBehaviour
{
    public PointEffector2D magnetEffector; // Reference to the magnet's effector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerDomino")) // Ensure domino is tagged correctly
        {
            // Enable the magnet effector
            magnetEffector.enabled = true;
            Debug.Log("Magnet Activated!");
        }
    }
}
