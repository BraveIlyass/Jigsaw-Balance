using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool isConnected = false;
    public HashSet<PuzzlePiece> connectedPieces = new HashSet<PuzzlePiece>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isConnected)
        {
            // Simulate connection update
            connectedPieces.Add(this); // Add self to connected pieces
            PuzzleManager.Instance.RegisterConnectedPiece(this); // Inform the manager
            SetKinematic(true); // Make the piece kinematic if its set as connected

            Debug.Log($"{gameObject.name} is marked as connected in the editor and registered with PuzzleManager.");
            return;

        }
    }

    public void ConnectTo(PuzzlePiece otherPiece)
    {
        if (!connectedPieces.Contains(otherPiece))
        {
            connectedPieces.Add(otherPiece);
            otherPiece.connectedPieces.Add(this);

            isConnected = true;
            otherPiece.isConnected = true;
            SetKinematic(true); // Make the piece kinematic on connect


            // Inform the manager about the new connection
            PuzzleManager.Instance.UpdateConnection(this, true);
            PuzzleManager.Instance.UpdateConnection(otherPiece, true);

        }
    }

    public void DisconnectFrom()
    {
        // Create a list to hold the pieces to be disconnected
        List<PuzzlePiece> piecesToDisconnect = new List<PuzzlePiece>(connectedPieces);

        // Disconnect from each piece in the list
        foreach (var connectedPiece in piecesToDisconnect)
        {
            connectedPiece.connectedPieces.Remove(this);
            Debug.Log("This Piece got disconnected");

        }

        // Clear the connected pieces set
        connectedPieces.Clear();
        isConnected = false;
        SetKinematic(false); // Make the piece non-kinematic on disconnect


        // Update the PuzzleManager about this disconnection
        PuzzleManager.Instance.UpdateConnection(this, false);



    }

    public float GetMass()
    {
        return rb != null ? rb.mass : 0f;
    }

    public bool IsFullyConnected()
    {
        return connectedPieces.Count > 0;
    }

    public bool IsConnected
    {
        get { return isConnected; }
        set { isConnected = value; }
    }


    public void SetKinematic(bool isKinematic)
    {
        if (rb != null)
        {
            rb.isKinematic = isKinematic;
        }
    }
}
