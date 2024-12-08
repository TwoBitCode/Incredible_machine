using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;

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
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
