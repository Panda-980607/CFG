using TMPro;
using UnityEngine;

public class DropDownChecker : MonoBehaviour
{
    public TMP_Dropdown[] dropdowns;
    public int[] correctDropdownIndexes;
    public GameObject successMessage;
    public GameObject failureMessage;


 
    public void checkDropDown()
    {
        bool allCorrect = true; 
        for (int i = 0; i < dropdowns.Length; i++)
        {
            if (dropdowns[i].value != correctDropdownIndexes[i])
            {
                allCorrect = false;
            }
        }

     
        if (allCorrect)
        {
            successMessage.SetActive(true);
            failureMessage.SetActive(false);
            //Debug.Log("All answers are correct.");
        }
        else
        {
            successMessage.SetActive(false); // Hide success message
            failureMessage.SetActive(true);  // Show failure message
          
            //Debug.Log("Some answers are incorrect:");
          
        }
    }
}
