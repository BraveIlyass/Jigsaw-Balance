using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHolder : MonoBehaviour
{
    private List<Transform> puzzlePieces = new List<Transform>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePiece"))
        {
            // Add the puzzle piece to the list
            puzzlePieces.Add(collision.transform);
            // Set the parent to this holder
            collision.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePiece"))
        {
            // Remove the puzzle piece from the list
            puzzlePieces.Remove(collision.transform);
            // Check if there are still puzzle pieces in the list
            if (puzzlePieces.Count == 0)
            {
                // If no puzzle pieces are left, set the parent to null
                collision.transform.parent = null;
            }
        }
    }
}
