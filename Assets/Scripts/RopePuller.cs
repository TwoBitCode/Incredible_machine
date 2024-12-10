using UnityEngine;

public class SidewaysDrag : MonoBehaviour
{
    public Rigidbody2D weight; // The weight to be dragged
    public float forceAmount = 1000f; // The amount of force to apply to the weight
    public float minX = -5f; // Minimum X position for the weight
    public float maxX = 5f; // Maximum X position for the weight

    private bool isActivated = false; // Tracks if the weight has been activated

    void Update()
    {
        // Apply force when the weight is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the mouse clicked on the weight
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null && hitCollider.gameObject == weight.gameObject && !isActivated)
            {
                ApplyForceToWeight();
                isActivated = true; // Prevent multiple activations
            }
        }

        // Clamp the X position of the weight
        Vector2 clampedPosition = weight.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        weight.position = clampedPosition;
    }

    private void ApplyForceToWeight()
    {
        weight.AddForce(Vector2.right * forceAmount, ForceMode2D.Impulse); // Apply force to the right
        Debug.Log("Weight hit with force!");
    }
}
