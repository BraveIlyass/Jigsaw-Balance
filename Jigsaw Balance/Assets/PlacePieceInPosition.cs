using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePieceInPosition : MonoBehaviour
{
    Vector3 piecePosition;
    [SerializeField] Transform piecePlaceHolderPosition;

    void Start()
    {
        piecePosition = transform.position;
    }

    void FixedUpdate()
    {

        if (TriggerIn.instance.canBePlaced || TriggerOut.instance.canBePlaced)
        {
            //Debug.Log("Puzzle Piece can be placed");
            piecePosition = piecePlaceHolderPosition.position;
            DragAndRotateObject.SelectedPiece.transform.position = piecePosition; // Update the position
        }

    }
}
