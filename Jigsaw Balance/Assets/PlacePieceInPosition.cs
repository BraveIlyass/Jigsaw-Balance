using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePieceInPosition : MonoBehaviour
{
    Transform piecePlaceHolderPosition;
    bool dragInProgress;

    float pushForce = 6f; // Adjust this value to control the amount of force applied
    float pushDuration = .3f; // Adjust this value to control the duration of the push

    private Vector3 targetPosition;
    private float pushStartTime;

    void Start()
    {
        DragAndRotateObject.OnDraggingStateChanged += HandleDraggingStateChanged;
    }

    void HandleDraggingStateChanged(bool isDragging)
    {
        dragInProgress = isDragging;
    }

    void Update()
    {
        DragAndRotateObject selectedPiece = DragAndRotateObject.SelectedPiece;

        if (!NoActionZone.instance.isInNoActionZone)
        {
            if (selectedPiece != null)
            {
                //Debug.Log("Slot.instance.canBePlaced -------" + Slot.instance.canBePlaced + "-------");
                //Debug.Log("selectedPiece.collidedWithPosition -------" + selectedPiece.collidedWithPosition + "-------");
                if (Slot.instance.canBePlaced && selectedPiece.collidedWithPosition != Vector3.zero)
                {
                    UpdatePosition(selectedPiece.collidedWithPosition);
                    // Reset collidedWithPosition when the piece is placed
                    selectedPiece.collidedWithPosition = Vector3.zero;
                }

                if (Tab.instance.canBePlaced && selectedPiece.collidedWithPosition != Vector3.zero)
                {
                    UpdatePosition(selectedPiece.collidedWithPosition);
                    // Reset collidedWithPosition when the piece is placed
                    selectedPiece.collidedWithPosition = Vector3.zero;
                }
            }
        }
        else if (NoActionZone.instance.isInNoActionZone && !dragInProgress)
        {
            if (Time.time - pushStartTime < pushDuration)
            {
                float t = (Time.time - pushStartTime) / pushDuration;
                selectedPiece.transform.position = Vector3.Lerp(selectedPiece.transform.position, targetPosition, t);
            }
            else
            {
                // Generate a new random direction after the push is complete
                targetPosition = selectedPiece.transform.position;

                Vector2 randomDirection = Random.insideUnitCircle.normalized;
                Vector3 pushVector = new Vector3(randomDirection.x, randomDirection.y, 0) * pushForce;
                targetPosition += pushVector;

                pushStartTime = Time.time;
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