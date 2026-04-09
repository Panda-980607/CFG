using TMPro;
using UnityEngine;

public class Auto1 : MonoBehaviour
{
    // First table text fields
    public TextMeshProUGUI SkillLevel1;



    // Second table text fields
    public TextMeshProUGUI SkillLevel2;



    // List of profiles hard coded XD ChatGPT
    private string[,] profiles = new string[,]
    {
        { "8"},
        { "7"},
        { "8"},
        { "9"},
        { "10"},
        { "6"},
        { "5"},
        { "8"},
        { "7"},
        { "9"}
    };

    // Start is called before the first frame update
    void Start()
    {
        // random index from the list
        int randomIndex = Random.Range(0, profiles.GetLength(0));

        // 2 tables 
        AssignProfile(randomIndex, SkillLevel1);
        AssignProfilecode(randomIndex, SkillLevel2);
        // add tables

    }

    // Function to assign values to a table
    void AssignProfile(int index, TextMeshProUGUI SkillLevel1)
    {
        SkillLevel1.text = profiles[index, 0];

    }
    void AssignProfilecode(int index, TextMeshProUGUI SkillLevel2)
    {
        SkillLevel2.text = profiles[index, 0];

    }
}
