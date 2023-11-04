using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInOut : MonoBehaviour
{
    public static TriggerInOut instance;

    bool dragInProgress = false;
    [HideInInspector] public bool canBePlaced = false;

    [SerializeField] string compatibleNib;

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
        //Debug.Log(collision.CompareTag(compatibleNib));

        if (collision.CompareTag(compatibleNib) && !dragInProgress)
        {
            //Debug.Log(dragInProgress);
            canBePlaced = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

    }
}
