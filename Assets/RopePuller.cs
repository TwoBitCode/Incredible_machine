using UnityEngine;

public class SidewaysDrag : MonoBehaviour
{
    public Rigidbody2D weight; // The weight to be dragged
    public float minX = -5f; // Minimum X position
    public float maxX = 5f; // Maximum X position

    private bool isDragging = false; // Tracks whether the player is dragging the weight

    void Update()
    {
        // Start dragging only when the mouse is clicked on the weight
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the mouse clicked on the weight
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null && hitCollider.gameObject == weight.gameObject)
            {
                isDragging = true;
            }
        }

        // Stop dragging when the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Apply movement only while dragging
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float targetX = Mathf.Clamp(mousePosition.x, minX, maxX); // Clamp to X-axis boundaries
            weight.position = new Vector2(targetX, weight.position.y); // Move only along the X-axis
        }
    }
}
