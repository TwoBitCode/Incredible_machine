using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject gate; // Assign the gate GameObject here

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")) // Ensure the ball is tagged correctly
        {
            Debug.Log("Switch Activated!");
            gate.SetActive(false); // Opens the gate by disabling it
        }
    }
}
