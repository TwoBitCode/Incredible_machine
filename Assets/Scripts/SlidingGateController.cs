using UnityEngine;

public class SlidingGateController : MonoBehaviour
{
    [Header("Gate Settings")]
    [SerializeField] private SliderJoint2D gateJoint;      // The sliding gate joint

    [Header("Motor Settings")]
    [SerializeField] private float motorSpeed = -5f;       // Speed of the gate movement
    [SerializeField] private float maxMotorTorque = 1000f; // Maximum force the motor can apply

    [Header("Trigger Settings")]
    [SerializeField] private string triggeringTag = "Ball";  // Tag required for activation

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggeringTag)) // Ensure the correct tag is checked
        {
            Debug.Log("Switch Activated!");

            JointMotor2D motor = new JointMotor2D
            {
                motorSpeed = motorSpeed,         // Use serialized field
                maxMotorTorque = maxMotorTorque  // Use serialized field
            };
            gateJoint.motor = motor;
            gateJoint.useMotor = true;
        }
    }
}
