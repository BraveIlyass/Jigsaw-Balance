using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScalePlatform leftPlatform;
    public ScalePlatform rightPlatform;

    void Update()
    {
        ScalePlatform.CompareAndAdjustPlatforms(leftPlatform, rightPlatform);
    }
}
