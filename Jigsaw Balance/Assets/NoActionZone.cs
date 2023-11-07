using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoActionZone : MonoBehaviour
{
    [HideInInspector] public string targetTag = "NoActionZone"; 

    [HideInInspector]public static NoActionZone instance;

    [HideInInspector] public bool isInNoActionZone = false;

    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isInNoActionZone = true;

            //Debug.Log("No Action zone is activated");
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isInNoActionZone = true;
            //Debug.Log("No Action zone is activated");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isInNoActionZone = false;
            //Debug.Log("No Action zone is Disabled");
        }
    }
}
