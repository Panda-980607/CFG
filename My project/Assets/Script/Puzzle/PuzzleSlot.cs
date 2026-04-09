using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
 
    public int correctPieceIndex;  // correct index
    public Puzzlepiece currentPiece;  // current index

    public void OnDrop(Puzzlepiece draggable)
    {

        if (currentPiece != null) 
        {
            draggable.transform.position = draggable.originalPosition;
            return;
        }
        currentPiece = draggable; // current drag
        
        draggable.transform.position = transform.position; // relocation


        //Debug
        //Debug.Log(draggable.name + " dropped on " + gameObject.name);

    }

    // checker
    public bool IsCorrect()
    {
        if (currentPiece == null)
            return false;

        return currentPiece.pieceIndex == correctPieceIndex;
    }
}
