using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    // Assuming each puzzle piece has a Rigidbody2D component
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float GetMass()
    {
        return rb != null ? rb.mass : 0f;
    }
}
