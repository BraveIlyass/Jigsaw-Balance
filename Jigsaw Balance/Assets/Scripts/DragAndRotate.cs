using UnityEngine;

public class DragAndRotate : MonoBehaviour
{
    public bool selected = false;
    private Vector3 offset;
    private float zPosition;
    private Renderer _renderer;

    [SerializeField] GameObject[] confiners;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
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
            _renderer.sortingOrder = 1;
        }
    }

    void OnMouseDrag()
    {
        if (selected)
        {
            Vector3 cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
            Vector3 objectPosition = Camera.main.ScreenToWorldPoint(cursorPosition) + offset;
            transform.position = objectPosition;

            // Call SetConfiners here, after the drag operation begins
            SetConfiners(selected);
        }
    }

    void OnMouseUp()
    {
        if (selected)
        {
            selected = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);

            // Reset sortingOrder
            _renderer.sortingOrder = 0;

            // Call SetConfiners here, after the drag operation ends
            SetConfiners(selected);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            transform.Rotate(Vector3.forward * -90f);
        }
    }

    // Function that goes through all confiners in a puzzle and set their active state to that of select, meaning if an object is not selected, it does not have a reason for its confiners to be active.
    void SetConfiners(bool isSelected)
    {
        foreach (var confiner in confiners)
        {
            if (confiner != null)
            {
                confiner.SetActive(isSelected);
            }
        }
    }
}
