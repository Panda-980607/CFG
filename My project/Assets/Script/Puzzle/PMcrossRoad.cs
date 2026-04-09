using UnityEngine;

public class PMcrossRoad : MonoBehaviour
{
    public PuzzleSlot[] puzzleSlots;  // slots
    public Puzzlepiece[] puzzlePieces;  // answers
    public GameObject successMessage;
    public GameObject failureMessage;

    public MoveS Success;// for correct
    public MoveF Fail;// for incorrect

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


            Success.StartCoroutine(Success.MoveToTarget(Success.Finish.position));
            successMessage.SetActive(true);
            failureMessage.SetActive(false);
            Debug.Log("Yeah all correct");


        }
        else
        {
            Fail.StartCoroutine(Fail.MoveToTarget(Fail.Finish.position));
            successMessage.SetActive(false);
            failureMessage.SetActive(true);
            Debug.Log("Nah something went wrong");
        }
    }
}
