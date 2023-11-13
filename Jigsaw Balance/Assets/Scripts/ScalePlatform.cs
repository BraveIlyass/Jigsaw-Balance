using UnityEngine;

public class ScalePlatform : MonoBehaviour
{
    public Transform puzzleHolder;
    public Vector3 initialPosition;
    public float movementFactor = 0.1f;
    public float movementSpeed = 1f;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
    }

    void Update()
    {
        SmoothlyMoveToTarget();
    }

    float CalculateTotalMass()
    {
        float totalMass = 0f;
        foreach (Transform child in puzzleHolder)
        {
            PuzzlePiece piece = child.GetComponent<PuzzlePiece>();
            if (piece != null)
            {
                totalMass += piece.GetMass();
            }
        }
        return totalMass;
    }

    void SmoothlyMoveToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movementSpeed);
    }

    public void UpdateTargetPosition(float positionOffset)
    {
        targetPosition = initialPosition + Vector3.down * positionOffset;
    }

    public static void CompareAndAdjustPlatforms(ScalePlatform leftPlatform, ScalePlatform rightPlatform)
    {
        float leftMass = leftPlatform.CalculateTotalMass();
        float rightMass = rightPlatform.CalculateTotalMass();

        float massDifference = leftMass - rightMass;
        float leftPositionOffset = massDifference * leftPlatform.movementFactor;
        float rightPositionOffset = -massDifference * rightPlatform.movementFactor;

        leftPlatform.UpdateTargetPosition(leftPositionOffset);
        rightPlatform.UpdateTargetPosition(rightPositionOffset);
    }
}
