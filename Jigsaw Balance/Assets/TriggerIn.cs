using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIn : MonoBehaviour
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


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Out") && !compatibility)
        {
            Debug.Log(compatibility);

        }

    }
}
