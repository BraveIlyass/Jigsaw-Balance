using UnityEngine;
using System;

public class DragAndRotate : MonoBehaviour
{
    public static DragAndRotate CurrentlySelected { get; private set; }
    public bool selected = false;
    public Action<GameObject> OnPickedUp;
    public Action<GameObject> OnDropped;
    private Vector3 offset;
    private float zPosition;
    private Renderer _renderer;
    private Rigidbody2D rb;
    [SerializeField] GameObject[] confiners;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        SetConfiners(false); // Initialize all confiners to inactive
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
        if (selected)
        {
            OnMouseDrag();
        }
    }

    void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            selected = true;
            CurrentlySelected = this;

            transform.SetParent(null); // Deparent the puzzle piece when picked up
            rb.gravityScale = 0; // Set gravity to 0 when picked up

            zPosition = transform.position.z;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            _renderer.sortingOrder = 1;

            OnPickedUp?.Invoke(gameObject);

            SetConfiners(true); // Activate confiners when selected
        }
    }

    void OnMouseDrag()
    {
        Vector3 cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPosition);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(cursorPosition) + offset;
        transform.position = objectPosition;
    }

    void OnMouseUp()
    {
        if (selected)
        {
            selected = false;
            CurrentlySelected = null;

            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
            _renderer.sortingOrder = 0;

            bool isChildOfPuzzleHolder = false;
            Collider2D[] hitColliders = Physics2D.OverlapPointAll(transform.position);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.GetComponent<PuzzleHolder>() != null)
                {
                    transform.SetParent(hitCollider.transform, worldPositionStays: true);
                    isChildOfPuzzleHolder = true;
                    break;
                }
            }

            rb.gravityScale = isChildOfPuzzleHolder ? 1 : 0; // Set gravity based on whether it's a child of PuzzleHolder

            OnDropped?.Invoke(gameObject);

            SetConfiners(false); // Deactivate confiners when not selected
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            transform.Rotate(Vector3.forward * -90f);
        }
    }

    // Function to set the active state of all confiners based on the selection status
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
