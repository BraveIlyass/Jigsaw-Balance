using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    private HashSet<PuzzlePiece> connectedPieces = new HashSet<PuzzlePiece>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Ensures only one instance of PuzzleManager exists
        }
        else
        {
            Instance = this;
        }
    }

    public void RegisterPiece(PuzzlePiece piece)
    {
        // If the piece is already connected, add it to the set
        if (piece.IsConnected)
        {
            connectedPieces.Add(piece);
        }
    }

    public void UpdateConnection(PuzzlePiece piece, bool isConnected)
    {
        if (isConnected)
        {
            connectedPieces.Add(piece);
        }
        else
        {
            connectedPieces.Remove(piece);
        }
    }

    public bool AreAllPiecesConnected(PuzzlePiece[] pieces)
    {
        HashSet<PuzzlePiece> checkedPieces = new HashSet<PuzzlePiece>();

        foreach (var piece in pieces)
        {
            if (!piece.IsFullyConnected() || checkedPieces.Contains(piece))
            {
                return false;
            }
            foreach (var connectedPiece in piece.connectedPieces)
            {
                checkedPieces.Add(connectedPiece);
            }
        }

        return checkedPieces.Count == pieces.Length;
    }

    private bool HasDisconnectedPieces()
    {
        foreach (var piece in connectedPieces)
        {
            foreach (var connectedPiece in piece.connectedPieces)
            {
                if (!connectedPieces.Contains(connectedPiece))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void RegisterConnectedPiece(PuzzlePiece piece)
    {
        // Logic to handle a piece that is marked as connected from the start
        // This can include adding it to a set of connected pieces, etc.
        connectedPieces.Add(piece);
        Debug.Log($"Registered {piece.gameObject.name} as a connected piece.");
        // Additional logic if needed to update the puzzle's completion status
    }
}
