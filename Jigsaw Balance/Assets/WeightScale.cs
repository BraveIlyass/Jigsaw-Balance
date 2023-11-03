using UnityEngine;

public class WeightScale : MonoBehaviour
{
    Rigidbody2D scaleRB;
    private Vector3 neutralPosition;
    private Vector3 targetPosition;
    private int numCollisions = 0;
    private float totalMass;

    void Start()
    {
        scaleRB = GetComponent<Rigidbody2D>();
        neutralPosition = scaleRB.position;
        targetPosition = neutralPosition;
    }

    void Update()
    {
        ApplyWeightOnScale();
        RemoveWeightFromScale();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D collidedRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collidedRigidbody != null)
        {
            numCollisions++;
            totalMass += collidedRigidbody.mass;
            targetPosition.y -= collidedRigidbody.mass;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D collidedRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collidedRigidbody != null)
        {
            numCollisions--;
            totalMass -= collidedRigidbody.mass;
            targetPosition.y += collidedRigidbody.mass;
        }
    }

    void ApplyWeightOnScale()
    {
        if (numCollisions > 0)
        {
            if (scaleRB.position.y <= targetPosition.y)
            {
                scaleRB.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                scaleRB.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    void RemoveWeightFromScale()
    {
        if (numCollisions == 0)
        {
            if (scaleRB.position.y < targetPosition.y)
            {
                scaleRB.bodyType = RigidbodyType2D.Dynamic;
                scaleRB.gravityScale = -1;
            }
            else
            {
                scaleRB.bodyType = RigidbodyType2D.Static;
                scaleRB.gravityScale = 1;
            }
        }
    }
}
