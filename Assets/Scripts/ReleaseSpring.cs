using UnityEngine;

public class ReleaseSpring : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public FixedJoint2D fixedJoint;
    public float springForce = 20f;  // Increase for higher jump
    public KeyCode activationKey = KeyCode.Space;

    void Update()
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
            ballRigidbody.AddForce(Vector2.up * springForce, ForceMode2D.Impulse);  // Apply upward force
        }
    }
}
