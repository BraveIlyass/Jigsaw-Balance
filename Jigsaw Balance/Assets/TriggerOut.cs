using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOut : MonoBehaviour
{
    bool compatibility = false;

    void Start()
    {
        DragAndRotateObject.OnDraggingStateChanged += HandleDraggingStateChanged;
    }

    void HandleDraggingStateChanged(bool isDragging)
    {
        compatibility = isDragging;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("In") && !compatibility)
        {
            Debug.Log(compatibility);

        }
    }
}
