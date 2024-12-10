using UnityEngine;

public class MagnetStick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetBall"))
        {
            // Attach a Fixed Joint 2D to the ball when it hits the magnet
            Rigidbody2D ballRb = collision.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                FixedJoint2D joint = collision.gameObject.AddComponent<FixedJoint2D>();
                joint.connectedBody = GetComponent<Rigidbody2D>();
                Debug.Log("Ball Stuck to Magnet!");
            }
        }
    }
}
