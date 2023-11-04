using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePieceInPosition : MonoBehaviour
{
    [SerializeField] Transform piecePlaceHolderPosition;

    void Update()
    {
        DragAndRotateObject selectedPiece = DragAndRotateObject.SelectedPiece;

        if (selectedPiece != null)
        {
            if (TriggerIn.instance.canBePlaced && selectedPiece.collidedWithPosition != Vector3.zero)
            {
                UpdatePosition(selectedPiece.collidedWithPosition);
            }

            if (TriggerOut.instance.canBePlaced && selectedPiece.collidedWithPosition != Vector3.zero)
            {
                UpdatePosition(selectedPiece.collidedWithPosition);
            }
        }
    }

    private void UpdatePosition(Vector3 newPosition)
    {
        DragAndRotateObject selectedPiece = DragAndRotateObject.SelectedPiece;
        if (selectedPiece != null)
        {
            selectedPiece.transform.position = newPosition;
        }
    }
}
