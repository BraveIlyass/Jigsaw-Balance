using UnityEngine;

public class DragAndRotateObject : MonoBehaviour
{
    public delegate void DraggingStateChangedEventHandler(bool isDragging);
    public static event DraggingStateChangedEventHandler OnDraggingStateChanged;

    public static DragAndRotateObject SelectedPiece { get; private set; }

    private bool isDragging = false;

    private Vector3 offset;
    private float targetRotation = 0.0f;
    public float rotationAmount = -90.0f;


    [HideInInspector] public Vector3 collidedWithPosition;


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
        NotifyDraggingStateChanged(true);

        SelectedPiece = null; // Set the currently selected piece


        Debug.Log("Is trying to drag is it working ?????");
    }

    void OnMouseUp()
    {

        isDragging = false;
        NotifyDraggingStateChanged(false);

        SelectedPiece = this; // Set the currently selected piece

    }

    void OnMouseDrag()
    {
        isDragging = true;
        NotifyDraggingStateChanged(true);
    }
    void RotateObject()
    {
        transform.rotation = Quaternion.Euler(0, 0, targetRotation);
    }


    void NotifyDraggingStateChanged(bool isDragging)
    {
        if (OnDraggingStateChanged != null)
        {
            OnDraggingStateChanged(isDragging);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlaceHolder"))
        {
            collidedWithPosition = collision.transform.position;
        }

    }
}
