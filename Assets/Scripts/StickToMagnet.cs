using UnityEngine;

public class StickToMagnet : MonoBehaviour
{
    private Rigidbody2D stuckBall;
    private bool isMagnetActive = true; // Check if the magnet is active

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetBall") && isMagnetActive)
        {
            stuckBall = collision.GetComponent<Rigidbody2D>();
            if (stuckBall != null)
            {
                // Stop all movement and attach the ball
                stuckBall.linearVelocity = Vector2.zero; // Updated to use linearVelocity
                stuckBall.angularVelocity = 0f;
                stuckBall.bodyType = RigidbodyType2D.Static;

                Debug.Log("Ball Stuck to the Magnet!");
            }
        }
    }

    public void ReleaseBall()
    {
        if (stuckBall != null)
        {
            // Reset the Rigidbody to dynamic
            stuckBall.bodyType = RigidbodyType2D.Dynamic;

            // Clear velocities
            stuckBall.linearVelocity = Vector2.zero;
            stuckBall.angularVelocity = 0f;
            stuckBall.position += Vector2.down * 0.1f;

            stuckBall = null; // Clear reference

            Debug.Log("Ball Released from the Magnet!");
        }

        // Deactivate the magnet
        isMagnetActive = false;
    }


    public void ReactivateMagnet()
    {
        isMagnetActive = true;
        Debug.Log("Magnet Reactivated!");
    }
}
