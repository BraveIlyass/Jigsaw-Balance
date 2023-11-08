using UnityEngine;

public class PositionSetter : MonoBehaviour
{
    public OverlapDetection overlapDetectionSlot;
    public OverlapDetection overlapDetectionTab;
    public DragAndRotate dragAndRotate;

    // Update is called once per frame
    void Update()
    {
        if(overlapDetectionSlot.canBePlaced && !dragAndRotate.selected)
        {
            this.transform.position = overlapDetectionSlot.newPositionOfPuzzlePiece.position;
            overlapDetectionSlot.canBePlaced = false;
        }
        
        if(overlapDetectionTab.canBePlaced && !dragAndRotate.selected)
        {
            this.transform.position = overlapDetectionTab.newPositionOfPuzzlePiece.position;
            overlapDetectionTab.canBePlaced = false;
        }
    }
}
