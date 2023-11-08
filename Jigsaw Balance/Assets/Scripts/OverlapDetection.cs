using UnityEngine;

public class OverlapDetection : MonoBehaviour
{
    [SerializeField] string lookForThisTag;
    [HideInInspector] public bool canBePlaced = false;
    [HideInInspector] public Transform newPositionOfPuzzlePiece;
    PlaceHolderPosition placeHolderPosition;

    // Reference to the currently active puzzle piece being dragged
    [HideInInspector] public Transform activePuzzlePiece;

    public DragAndRotate dragAndRotate;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (dragAndRotate.selected)//Do this operation only for the select puzzle piece
        {
            if (collision.gameObject.CompareTag(lookForThisTag))
            {
                placeHolderPosition = collision.gameObject.GetComponent<PlaceHolderPosition>();

                if (placeHolderPosition != null)
                {
                    newPositionOfPuzzlePiece = placeHolderPosition.placeHolderPosition;
                    canBePlaced = true;

                    // Set the active puzzle piece
                    activePuzzlePiece = transform.parent;
                }
                else
                {
                    canBePlaced = false;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (dragAndRotate.selected)//Do this operation only for the select puzzle piece
        {
            if (collision.gameObject.CompareTag(lookForThisTag))
            {
                canBePlaced = false;
            }
        }
    }
}
