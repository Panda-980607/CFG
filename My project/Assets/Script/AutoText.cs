using UnityEngine;
using TMPro;

public class AutoText : MonoBehaviour
{
    // First table text fields
    public TextMeshProUGUI nameText1;
    public TextMeshProUGUI eyeColorText1;
    public TextMeshProUGUI heightText1;
    public TextMeshProUGUI tattooText1;
    public TextMeshProUGUI hairColorText1;
    // Second table text fields
    public TextMeshProUGUI nameText2;
    public TextMeshProUGUI eyeColorText2;
    public TextMeshProUGUI heightText2;
    public TextMeshProUGUI tattooText2;
    public TextMeshProUGUI hairColorText2;

    // List of profiles hard coded XD ChatGPT
    private string[,] profiles = new string[,]
    {
        { "Edward", "Magenta", "191", "false", "Magenta" },
        { "David", "White", "177", "true", "Red" },
        { "Fox", "Yellow", "180", "true", "Magenta" },
        { "David", "White", "177", "true", "Red" },
        { "Bob", "Blue", "180", "true", "Magenta" },
        { "Edward", "White", "155", "true", "Blue" },
        { "Chris", "Yellow", "192", "true", "White" },
        { "Bob", "Blue", "161", "false", "Magenta" },
        { "Chris", "Red", "120", "false", "Red" },
        { "Fox", "Green", "180", "true", "Cyan" }
    };

    // Start is called before the first frame update
    void Start()
    {
        // random index from the list
        int randomIndex = Random.Range(0, profiles.GetLength(0));

        // 2 tables 
        AssignProfile(randomIndex, nameText1, eyeColorText1, heightText1, tattooText1, hairColorText1);
        AssignProfilecode(randomIndex, nameText2, eyeColorText2, heightText2, tattooText2, hairColorText2);
        // add tables

    }

    // Function to assign values to a table
    void AssignProfile(int index, TextMeshProUGUI name1, TextMeshProUGUI eyeColor1, 
        TextMeshProUGUI height1, TextMeshProUGUI tattoo1, TextMeshProUGUI hairColor1)
    {
        name1.text = profiles[index, 0];
        eyeColor1.text = profiles[index, 1];
        height1.text = profiles[index, 2];
        tattoo1.text = profiles[index, 3] == "true" ? "Yes" : "No";
        hairColor1.text = profiles[index, 4];
    }
    void AssignProfilecode(int index, TextMeshProUGUI name2, TextMeshProUGUI eyeColor2,
        TextMeshProUGUI height2, TextMeshProUGUI tattoo2, TextMeshProUGUI hairColor2)
    {
        name2.text = $"\"{profiles[index, 0]}\"";
        eyeColor2.text = $"\"{profiles[index, 1]}\"";
        height2.text = profiles[index, 2]; 
        tattoo2.text = profiles[index, 3]; 
        hairColor2.text = $"\"{profiles[index, 4]}\"";
    }
}
