using UnityEngine;

public class PuzzleHolder : MonoBehaviour
{
    //private float totalMasse = 0f;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePiece"))
        {
            var dragAndRotate = collision.GetComponent<DragAndRotate>();
            if (dragAndRotate != null && dragAndRotate != DragAndRotate.CurrentlySelected)
            {
                collision.transform.SetParent(transform);
            }
        }
    }

    // Optional: Add logic in OnTriggerExit2D if you want to deparent the puzzle piece when it exits the trigger area
    void OnTriggerExit2D(Collider2D collision)
    {
        // Your logic here, if needed
    }
}
