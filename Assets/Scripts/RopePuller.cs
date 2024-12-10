using UnityEngine;

public class SidewaysDrag : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D weight;  // The draggable weight

    [Header("Force Settings")]
    [SerializeField] private float forceAmount = 1000f;  // Adjustable force amount
    [SerializeField] private Vector2 forceDirection = Vector2.right;  // Direction of the force

    [Header("Clamping Settings")]
    [SerializeField] private float minX = -5f;  // Minimum X position
    [SerializeField] private float maxX = 5f;   // Maximum X position

    private bool isActivated = false;  // Prevents multiple activations

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the mouse clicked on the weight
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null && hitCollider.gameObject == weight.gameObject && !isActivated)
            {
                ApplyForceToWeight();
                isActivated = true;  // Prevent multiple activations
            }
        }

        // Clamp the X position of the weight
        ClampWeightPosition();
    }

    private void ApplyForceToWeight()
    {
        weight.AddForce(forceDirection * forceAmount, ForceMode2D.Impulse);  // Apply force
        Debug.Log("Weight hit with force!");
    }

    private void ClampWeightPosition()
    {
        Vector2 clampedPosition = weight.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);  // Keep within range
        weight.position = clampedPosition;
    }
}
