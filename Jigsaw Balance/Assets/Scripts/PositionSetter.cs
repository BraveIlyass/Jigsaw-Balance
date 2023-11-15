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
                    PuzzlePiece piece = GetComponent<PuzzlePiece>();
                    if (piece != null && !piece.IsConnected)
                    {
                        transform.position = detector.newPositionOfPuzzlePiece.position;
                        detector.canBePlaced = false;

                        UpdateConnections(detector);
                        break;
                    }
                }
            }
        }
    }

    private void UpdateConnections(OverlapDetection detector)
    {
        PuzzlePiece thisPiece = GetComponent<PuzzlePiece>();
        PuzzlePiece connectedPiece = detector.activePuzzlePiece.GetComponent<PuzzlePiece>();

        if (thisPiece != null && connectedPiece != null)
        {
            thisPiece.ConnectTo(connectedPiece);
        }
    }
}
