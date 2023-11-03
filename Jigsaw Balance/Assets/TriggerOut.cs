using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOut : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("In"))
        {
            Debug.Log("This is a possible fit");
        }
    }
}
