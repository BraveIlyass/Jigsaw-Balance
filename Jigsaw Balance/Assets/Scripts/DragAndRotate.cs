using UnityEngine;

public class DragAndRotate : MonoBehaviour
{
    public bool selected = false;
    private Vector3 offset;
    private float zPosition;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            selected = true;
            zPosition = transform.position.z;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

            // Set sortingOrder to ensure the object is on top
            renderer.sortingOrder = 1;
        }
    }

    void OnMouseDrag()
    {
        if (selected)
        {
            Vector3 cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
            Vector3 objectPosition = Camera.main.ScreenToWorldPoint(cursorPosition) + offset;
            transform.position = objectPosition;
        }
    }

    void OnMouseUp()
    {
        if (selected)
        {
            selected = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);

            // Reset sortingOrder
            renderer.sortingOrder = 0;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            transform.Rotate(Vector3.forward * -90f);
        }
    }
}
