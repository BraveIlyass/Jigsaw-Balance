using System.Collections;
using UnityEngine;

public class WeightManager : MonoBehaviour
{
    [SerializeField] GameObject platformLeft;
    [SerializeField] GameObject platformRight;

    WeightScalePlatform weightScalePlatformLeft;
    WeightScalePlatform weightScalePlatformRight;

    Vector3 initialPositionLeft;
    Vector3 initialPositionRight;

    float maxUpwardMovement = 2.0f;
    float maxDownwardMovement = -2.0f;

    private void Start()
    {
        initialPositionLeft = platformLeft.transform.position;
        initialPositionRight = platformRight.transform.position;

        weightScalePlatformLeft = platformLeft.GetComponent<WeightScalePlatform>();
        weightScalePlatformRight = platformRight.GetComponent<WeightScalePlatform>();
    }

    private void FixedUpdate()
    {
        AdjustWeightScale();
    }

    private void AdjustWeightScale()
    {
        float leftWeight = CalculateWeight(platformLeft.transform);
        float rightWeight = CalculateWeight(platformRight.transform);

        float weightDifference = rightWeight - leftWeight;

        if (weightDifference > 0)
        {
            MovePlatform(platformLeft.transform, weightDifference, maxUpwardMovement);
            MovePlatform(platformRight.transform, -weightDifference, maxDownwardMovement);
        }
        else if (weightDifference < 0)
        {
            MovePlatform(platformRight.transform, Mathf.Abs(weightDifference), maxUpwardMovement);
            MovePlatform(platformLeft.transform, -Mathf.Abs(weightDifference), maxDownwardMovement);
        }
        else
        {
            ResetPlatforms();
        }
    }

    private void MovePlatform(Transform platform, float distance, float maxMovement)
    {
        float newYPosition = platform.position.y + distance * 1f * Time.fixedDeltaTime;

        // Clamp the position within the specified movement range
        newYPosition = Mathf.Clamp(newYPosition, maxDownwardMovement, maxUpwardMovement);

        platform.position = new Vector3(platform.position.x, newYPosition, platform.position.z);
    }

    private float CalculateWeight(Transform platform)
    {
        // Your weight calculation logic here (assuming each PuzzlePiece has a weight of 1)
        return platform.childCount;
    }

    private IEnumerator MovePlatformTo(Transform platform, Vector3 targetPosition, float duration)
    {
        Vector3 initialPosition = platform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            platform.position = Vector3.Lerp(initialPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the platform reaches the exact target position
        platform.position = targetPosition;
    }

    private void ResetPlatforms()
    {
        // Reset platforms to their initial positions over a specified duration.
        StartCoroutine(MovePlatformTo(platformLeft.transform, initialPositionLeft, 1.0f));
        StartCoroutine(MovePlatformTo(platformRight.transform, initialPositionRight, 1.0f));
    }
}
