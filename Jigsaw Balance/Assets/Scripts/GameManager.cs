using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScalePlatform leftPlatform;
    public ScalePlatform rightPlatform;
    public PuzzleHolder leftPuzzleHolder; // Reference to the PuzzleHolder on the left platform
    public PuzzleHolder rightPuzzleHolder; // Reference to the PuzzleHolder on the right platform
    public PuzzlePiece[] allPuzzlePieces; // Array of all puzzle pieces in the scene


    float positionTolerance = .1f;

    void Update()
    {
        ScalePlatform.CompareAndAdjustPlatforms(leftPlatform, rightPlatform);
        CheckForWin();


        if (PuzzleManager.Instance.AreAllPiecesConnected(allPuzzlePieces))
        {
            Debug.Log("All Puzzle pieces are connected");
        }
    }

    void CheckForWin()
    {
        if (AreWeightsBalanced() && ArePlatformsNotEmpty() && AreAllPiecesOnPlatforms() && ArePlatformsInOriginalPosition())
        {
            Debug.Log("Game Won!"); 
            // Trigger any win-related actions here
        }


        if (IsPuzzleSolved())
        {
            //Debug.Log("[GameManager] Puzzle solved check completed.");
        }
        else
        {
            //Debug.Log("[GameManager] Puzzle not solved check completed.");
        }
    }
        
    bool AreWeightsBalanced()
    {
        // Implement logic to check if weights are balanced
        // Example: Check if the total mass of each PuzzleHolder is approximately equal
        return Mathf.Abs(leftPlatform.CalculateTotalMass() - rightPlatform.CalculateTotalMass()) == 0;
    }

    bool ArePlatformsNotEmpty()
    {
        // Check if both PuzzleHolders have at least one puzzle piece
        return leftPuzzleHolder.transform.childCount > 0 && rightPuzzleHolder.transform.childCount > 0;
    }

    bool AreAllPiecesOnPlatforms()
    {
        // Check if each puzzle piece is a child of one of the PuzzleHolders
        foreach (var piece in allPuzzlePieces)
        {
            if (!piece.transform.IsChildOf(leftPuzzleHolder.transform) && !piece.transform.IsChildOf(rightPuzzleHolder.transform))
            {
                return false;
            }
        }
        return true;
    }


    bool ArePlatformsInOriginalPosition()
    {
        // Check if both platforms are close enough to their initial positions
        return Vector3.Distance(leftPlatform.transform.position, leftPlatform.initialPosition) < positionTolerance
            && Vector3.Distance(rightPlatform.transform.position, rightPlatform.initialPosition) < positionTolerance;
    }

    public bool IsPuzzleSolved()
    {
        foreach (var piece in allPuzzlePieces)
        {
            if (!piece.IsFullyConnected())
            {
                //Debug.Log($"[GameManager] Puzzle not solved. {piece.gameObject.name} is isolated.");
                return false;
            }
        }
        //Debug.Log("[GameManager] Puzzle solved!");
        return true;
    }
}
