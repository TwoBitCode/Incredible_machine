using UnityEngine;

public class SpringActivator : MonoBehaviour
{
    public SpringJoint2D springJoint;    // Spring Joint on the base
    public Rigidbody2D ball;            // Ball to be launched
    public float springForce = 20f;     // Adjust the spring force

    private bool isActivated = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isActivated)
        {
            ActivateSpring();
        }
    }

    private void ActivateSpring()
    {
        isActivated = true;

        // Apply force horizontally to the ball
        ball.AddForce(Vector2.right * springForce, ForceMode2D.Impulse);

        // Simulate release after a short delay
        Invoke(nameof(ResetSpring), 0.5f);
    }

    private void ResetSpring()
    {
        springJoint.distance = 1f;  // Reset distance (if applicable)
        isActivated = false;
    }
}
