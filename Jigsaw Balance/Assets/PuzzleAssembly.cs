using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAssembly : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("In"))
        {
            Debug.Log("This piece can go here");
        }
        else
        {
            Debug.Log("This Piece can't go here");
        }        
    }
}
