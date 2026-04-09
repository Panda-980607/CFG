using UnityEngine;


public class Puzzlepiece : MonoBehaviour
{
    private bool dragging = false;
    public Vector3 originalPosition;


    public int pieceIndex;
    // layer on target
    public LayerMask dropTargetLayer;

    void OnMouseDown()
    {
        // Save original position
        originalPosition = transform.position;
        dragging = true;
        // null the slot when piece move
        Collider2D[] overlapping = Physics2D.OverlapPointAll(transform.position, dropTargetLayer);
        foreach (Collider2D col in overlapping)
        {
            PuzzleSlot slot = col.GetComponent<PuzzleSlot>();
            if (slot != null && slot.currentPiece == this)
            {
                slot.currentPiece = null;
                break; // Only one slot should hold this piece
            }
        }
    }

    void OnMouseDrag()
    {
        if (dragging)
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        dragging = false;
        // Check if our position overlaps a drop target.
        Collider2D targetCollider = Physics2D.OverlapPoint(transform.position, dropTargetLayer);
        if (targetCollider != null)
        {
            // Get the PuzzleSlot component
            PuzzleSlot puzzleSlot = targetCollider.GetComponent<PuzzleSlot>();
            // if not empty go back
            if (puzzleSlot != null && puzzleSlot.currentPiece ==null)
            {
                // Put at position
                transform.position = targetCollider.transform.position;
                // Call OnDrop() method in the PuzzleSlot
                puzzleSlot.OnDrop(this);
                // Debug
                //Debug.Log("Dropped on valid target: " + targetCollider.name);
            }
            else
            {
                // If no PuzzleSlot component found, revert the puzzle piece position
                transform.position = originalPosition;
                //Debug.Log("Dropped on an invalid target. PuzzleSlot component not found.");
            }
        }
        else
        {
            // If no target was found, return to original position
            transform.position = originalPosition;
            //Debug.Log("Dropped on invalid area. Reverting.");
        }
    }
}
    
