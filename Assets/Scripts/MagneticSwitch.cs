using UnityEngine;

public class MagneticSwitch : MonoBehaviour
{
    public PointEffector2D magnetEffector; // Reference to the Point Effector 2D on the magnet

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerDomino")) // Ensure the domino triggers the switch
        {
            // Enable the magnet effector
            magnetEffector.enabled = true;
            Debug.Log("Magnet Activated!");
        }
    }
}
