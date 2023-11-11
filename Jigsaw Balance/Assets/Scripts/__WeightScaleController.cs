using UnityEngine;

public class WeightScaleController : MonoBehaviour
{
    public Transform leftPlatform;
    public Transform rightPlatform;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        Debug.Log(rb);
        if (rb != null)
        {
            float weight = rb.mass;

            if (rightPlatform.childCount == 0 || weight > GetTotalWeight(rightPlatform))
            {
                rb.transform.SetParent(rightPlatform);
                UpdateWeightScale();
            }
            else
            {
                rb.transform.SetParent(leftPlatform);
                UpdateWeightScale();
            }
        }
    }

    void UpdateWeightScale()
    {
        float leftWeight = GetTotalWeight(leftPlatform);
        float rightWeight = GetTotalWeight(rightPlatform);

        float weightDifference = leftWeight - rightWeight;
        float angle = Mathf.Clamp(weightDifference, -30f, 30f);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    float GetTotalWeight(Transform platform)
    {
        float totalWeight = 0;

        foreach (Transform child in platform)
        {
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                totalWeight += rb.mass;
            }
        }

        return totalWeight;
    }
}
