using UnityEngine;

public class MagneticSwitch : MonoBehaviour
{
    public GameObject magneticField; // Assign the Magnet GameObject (Gray Square)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerDomino")) // Make sure the triggering domino has this tag
        {
            // Activate the magnetic field
            magneticField.GetComponent<PointEffector2D>().enabled = true;

            Debug.Log("Magnet Activated!"); // Debugging message to confirm trigger
        }
    }
}
