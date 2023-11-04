using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIn : MonoBehaviour
{
    public static TriggerIn instance;

    bool dragInProgress = false;

    [HideInInspector] public bool canBePlaced = false;


    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        DragAndRotateObject.OnDraggingStateChanged += HandleDraggingStateChanged;
    }

    void HandleDraggingStateChanged(bool isDragging)
    {
        dragInProgress = isDragging;
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Out") && !dragInProgress)
        {
            canBePlaced = true;
        }
        else
        {
            canBePlaced = false;
        }
    }
}
