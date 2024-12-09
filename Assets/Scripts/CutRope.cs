using UnityEngine;

public class CutRope : MonoBehaviour
{
    private DistanceJoint2D joint;

    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only respond to collisions with objects tagged as "Knife"
        if (collision.gameObject.CompareTag("Knife"))
        {
            Destroy(joint); // Remove the joint to release the weight
            Destroy(gameObject); // Optionally destroy the rope
        }
    }
}
