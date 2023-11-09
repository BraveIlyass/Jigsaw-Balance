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
        // Ensure there's only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            rightOrientation = false;
            //Debug.Log("Can't be place");
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            rightOrientation = false;
            //Debug.Log("Can't be place");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Slot"))
        {
            rightOrientation = true;
        }
    }
}
