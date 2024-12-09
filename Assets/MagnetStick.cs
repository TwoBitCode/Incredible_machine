using UnityEngine;

public class MagnetStick : MonoBehaviour
{
    public Transform magnetCenter; // Assign the magnet's center
    public float pullSpeed = 5f; // Speed at which the ball moves to the magnet
    private bool isMagnetActive = false; // Track if the magnet is activated

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetBall") && isMagnetActive) // Check if magnet is active
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Disable physics and pull the ball
                rb.bodyType = RigidbodyType2D.Kinematic;
                StartCoroutine(PullToMagnet(collision.transform));
            }
        }
    }

    public void ActivateMagnet()
    {
        isMagnetActive = true; // Enable the magnet when the switch is triggered
        Debug.Log("Magnet Activated!");
    }

    private System.Collections.IEnumerator PullToMagnet(Transform ball)
    {
        while (Vector2.Distance(ball.position, magnetCenter.position) > 0.1f)
        {
            // Move the ball toward the magnet
            ball.position = Vector2.MoveTowards(ball.position, magnetCenter.position, pullSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap the ball to the target position
        ball.position = magnetCenter.position;
        Debug.Log("Ball Stuck to Magnet!");
    }
}
