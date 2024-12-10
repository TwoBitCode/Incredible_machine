using UnityEngine;

public class WindSwitchActivator : MonoBehaviour
{
    public AreaEffector2D windArea; // Reference to the wind area
    private bool windActive = false; // Tracks the state of the wind

    private void OnMouseDown() // Triggered when the switch is clicked
    {
        windActive = !windActive; // Toggle the state of the wind
        windArea.enabled = windActive; // Enable or disable the wind effect

        if (windActive)
        {
            Debug.Log("Wind Activated!");
        }
        else
        {
            Debug.Log("Wind Deactivated!");
        }
    }
}
