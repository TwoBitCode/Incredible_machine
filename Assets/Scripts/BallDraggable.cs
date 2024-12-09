using UnityEngine;

public class BallDraggable : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;

    [SerializeField]
    private float minX = -5f; // Minimum X position
    [SerializeField]
    private float maxX = 5f;  // Maximum X position

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = GetMouseWorldPosition() + offset;
        // Restrict movement to X-axis and clamp within range
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // Distance from the camera
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
