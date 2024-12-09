using UnityEngine;

public class UnfreezeBall : MonoBehaviour
{
    public Rigidbody2D ballRigidbody; // Assign the second ball's Rigidbody2D here

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Domino")) // Check if a domino hits this trigger
        {
            Debug.Log("Domino hit the ball! Unfreezing...");
            ballRigidbody.constraints = RigidbodyConstraints2D.None; // Unfreeze the ball
        }
    }
}
