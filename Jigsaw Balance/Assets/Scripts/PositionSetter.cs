using UnityEngine;

public class PositionSetter : MonoBehaviour
{
    public OverlapDetection[] overlapDetectors;
    public DragAndRotate dragAndRotate;

    void Update()
    {
        if (OrientationDetection.Instance.rightOrientation)
        {
            foreach (var detector in overlapDetectors)
            {
                if (detector.canBePlaced && !dragAndRotate.selected)
                {
                    transform.position = detector.newPositionOfPuzzlePiece.position;
                    detector.canBePlaced = false;
                    break; // Exit loop after first successful placement (if needed)
                }
            }
        }

    }
}
