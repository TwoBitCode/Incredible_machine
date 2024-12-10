using UnityEngine;

public class SpringActivator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpringJoint2D springJoint;  // Spring Joint on the base
    [SerializeField] private Rigidbody2D ball;          // Ball to be launched

    [Header("Spring Settings")]
    [SerializeField] private float springForce = 20f;   // Adjustable spring force
    [SerializeField] private Vector2 forceDirection = Vector2.right;  // Force direction

    [Header("Timing Settings")]
    [SerializeField] private float springResetDelay = 0.5f;  // Delay before resetting the spring
    [SerializeField] private float resetDistance = 1f;  // Distance to reset after launch

    [Header("Input Settings")]
    [SerializeField] private KeyCode activationKey = KeyCode.Space;  // Key for activating the spring

    private bool isActivated = false;

    private void Update()
    {
        if (Input.GetKeyDown(activationKey) && !isActivated)
        {
            ActivateSpring();
        }
    }

    private void ActivateSpring()
    {
        isActivated = true;

        // Apply force to the ball
        ball.AddForce(forceDirection * springForce, ForceMode2D.Impulse);
        Debug.Log("Spring activated!");

        // Reset spring after a delay
        Invoke(nameof(ResetSpring), springResetDelay);
    }

    private void ResetSpring()
    {
        springJoint.distance = resetDistance;  // Reset the spring distance
        isActivated = false;
        Debug.Log("Spring reset!");
    }
}
