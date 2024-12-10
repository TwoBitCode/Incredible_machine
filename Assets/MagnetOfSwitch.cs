using UnityEngine;

public class MagnetSwitch : MonoBehaviour
{
    public StickToMagnet stickToMagnetScript; // Reference to the StickToMagnet script
    public PointEffector2D magnetEffector; // Reference to the Point Effector 2D

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SwitchActivator")) // Ensure the right object triggers the switch
        {
            // Call the ReleaseBall method
            stickToMagnetScript.ReleaseBall();

            // Disable the Point Effector 2D
            if (magnetEffector != null)
            {
                magnetEffector.enabled = false;
                Debug.Log("Magnet Effector Disabled!");
            }

            Debug.Log("Magnet Turned Off and Ball Released!");
        }
    }
}
