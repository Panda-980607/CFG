using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public PuzzleSlot[] puzzleSlots;  // slots
    public Puzzlepiece[] puzzlePieces;  // answers
    public GameObject successMessage;  
    public GameObject failureMessage;

    public AutoMove autoMoveScript;// for correct
    public AutoFail autoMoveFailScript;// for incorrect

    // Submit button
    public void CheckPuzzle()
    {

        //Debug.Log("Checking puzzle...");    
        bool allCorrect = true;

        // Check
        for (int i = 0; i < puzzleSlots.Length; i++)
        {
            if (!puzzleSlots[i].IsCorrect())
            {
                allCorrect = false;
                //Debug.Log("wrong" + i);
                break;
            }
            //Debug.Log("correct" + i);
        }

        // Provide feedback
        if (allCorrect)
        {

            autoMoveScript.StartCoroutine(autoMoveScript.MoveSequence());
            successMessage.SetActive(true);  
            failureMessage.SetActive(false);  
           // Debug.Log("Yeah all correct");


        }
        else
        {
            autoMoveFailScript.StartCoroutine(autoMoveFailScript.MoveSequence());
            successMessage.SetActive(false);  
            failureMessage.SetActive(true);  
            //Debug.Log("Nah something went wrong");
        }
    }
   
}
