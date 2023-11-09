using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationDetection : MonoBehaviour
{
     [HideInInspector] public bool rightOrientation = true;

    // Singleton instance
    public static OrientationDetection Instance { get; private set; }


    private void Awake()
    {
        // Ensure there's only one instance of OrientationDetection
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            rightOrientation = false;
            //Debug.Log("Can't be place");
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            rightOrientation = false;
            //Debug.Log("Can't be place");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Slot"))
        {
            rightOrientation = true;
        }
    }
}
