using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputChecker : MonoBehaviour
{
    public TMP_InputField[] inputFields; // All boxes
    public string[] singleAnswers; // Only answer 
    public List<string>[] multipleAnswers; // possible answers for some

    public GameObject successMessage; // YES
    public GameObject failureMessage; // NAH
    public GameObject IntroTEXT;

    public bool[] hasMultipleAnswers; // Flags to indicate which fields accept multiple answers

    public void CheckAnswers()
    {
        multipleAnswers = new List<string>[]
        {
            new List<string> { "int", "short","long" }
        };
        bool allCorrect = true;

        for (int i = 0; i < inputFields.Length; i++)
        {
            string userInput = inputFields[i].text;
            bool isCorrect = false;

            if (hasMultipleAnswers[i])
            {
                // Check against multiple correct answers
                foreach (string correctAnswer in multipleAnswers[i])
                {
                    if (userInput == correctAnswer) // Case-sensitive check
                    {
                        isCorrect = true;
                        break;
                    }
                }
            }
            else
            {
                // Check against a single correct answer
                if (userInput == singleAnswers[i]) // Case-sensitive check
                {
                    isCorrect = true;
                }
            }

            if (!isCorrect)
            {
                allCorrect = false;
                break;
            }
        }

        // Show appropriate feedback
        if (allCorrect)
        {
            IntroTEXT.SetActive(false);
            successMessage.SetActive(true);
            failureMessage.SetActive(false);
            Debug.Log("YEAH");        
        }
        else
        {
            IntroTEXT.SetActive(false);
            successMessage.SetActive(false);
            failureMessage.SetActive(true);
            Debug.Log("NAH");
        }
    }
}
