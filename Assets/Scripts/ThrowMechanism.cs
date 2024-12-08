using UnityEngine;

public class ThrowMechanism : MonoBehaviour
{
    public Rigidbody2D arm; // Rigidbody of the throwing arm
    public float torqueForce = 500f; // Amount of rotational force


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Detect Space key
        {
            arm.AddTorque(-torqueForce); // Apply torque to rotate the arm
        }
    }
}
