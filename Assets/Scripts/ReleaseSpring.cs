using UnityEngine;

public class ReleaseSpring : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D ballRigidbody;  // Ball to launch
    [SerializeField] private FixedJoint2D fixedJoint;   // Joint connecting the ball

    [Header("Settings")]
    [SerializeField] private float springForce = 20f;   // Adjustable spring force
    [SerializeField] private KeyCode activationKey = KeyCode.Space;  // Key for activation

    private void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            ReleaseBall();
        }
    }

    private void ReleaseBall()
    {
        if (fixedJoint != null)
        {
            Destroy(fixedJoint);  // Release the ball from the spring
            ApplySpringForce();
        }
    }

    private void ApplySpringForce()
    {
        Vector2 launchDirection = Vector2.up;  // Defined direction for clarity
        ballRigidbody.AddForce(launchDirection * springForce, ForceMode2D.Impulse);  // Launch the ball
    }
}
