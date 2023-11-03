using UnityEngine;

public class DragAndRotateObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private float targetRotation = 0.0f;
    public float rotationAmount = -90.0f;

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
        }

        if (Input.GetMouseButtonDown(1) && isDragging) // Right mouse button clicked
        {
            targetRotation += rotationAmount;
            RotateObject();
        }
    }

    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;

        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null || !collider.OverlapPoint(mousePosition))
            return;

        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void RotateObject()
    {
        transform.rotation = Quaternion.Euler(0, 0, targetRotation);
    }
}
