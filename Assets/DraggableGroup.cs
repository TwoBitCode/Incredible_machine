using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;

    private void Start()
    {
        // Cache the main camera reference
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        // Calculate offset between mouse position and object position
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        // Move the object with the mouse while maintaining offset
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Ensure the main camera exists
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found!");
            return Vector3.zero;
        }

        // Convert mouse position to world position
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
