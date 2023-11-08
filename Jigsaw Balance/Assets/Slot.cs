using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public static Slot instance;

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

        // Reset canBePlaced when dragging state changes
        canBePlaced = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        canBePlaced = collision.CompareTag("Tab") && !dragInProgress;
        Debug.Log("Tag of the collision -------" + collision.tag + "-------");
        Debug.Log("Is player draging ?  -------" + dragInProgress + "-------");
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        canBePlaced = collision.CompareTag("Tab") && !dragInProgress;

    }

    void OnDestroy()
    {
        DragAndRotateObject.OnDraggingStateChanged -= HandleDraggingStateChanged;
    }
}
