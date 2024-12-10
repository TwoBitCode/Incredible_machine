using UnityEngine;

public class StickToMagnet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetBall"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Stop all movement
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;

                // Make the Rigidbody Static to lock it in place
                rb.bodyType = RigidbodyType2D.Static;

                Debug.Log("Ball Stuck to the Magnet!");
            }
        }
    }
}
