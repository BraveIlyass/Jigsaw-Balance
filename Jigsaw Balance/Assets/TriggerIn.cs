using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIn : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Out"))
        {
            Debug.Log("This is a possible fit");
        }
    }
}
