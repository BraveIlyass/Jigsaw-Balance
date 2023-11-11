using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightScalePlatform : MonoBehaviour
{
    public bool weightOnPlatform = false;


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePiece"))
        {
            //Debug.Log("Works");
            weightOnPlatform = true;

            // Make the collided object a child of the platform
            collision.transform.parent = transform;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePiece"))
        {
            //Debug.Log("Works");
            weightOnPlatform = false;

            // Make the collided object a child of the platform
            collision.transform.parent = null;
        }
    }
}
