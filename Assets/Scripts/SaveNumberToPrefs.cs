using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveNumberToPrefs : MonoBehaviour
{
    public Text numberText;  // Reference to the Text component (UI Text that displays the number)
    public Button saveButton;
    public Text numberText1;                          // Reference to the Button that will save the number

    private void Start()
    {
        // Add a listener to the button to call the SaveNumber function when pressed
        saveButton.onClick.AddListener(SaveNumber);
    }

    void SaveNumber()
    {
        // Get the number string from the Text component
        
        int num = PlayerPrefs.GetInt("zemlja_materials");
        Debug.Log(num);
        PlayerPrefs.SetInt("materials", num);
        numberText1.text = num.ToString();
        // Try to parse the number string into an integer
        /* if (int.TryParse(numberString, out int number))
        {
            // Save the number to PlayerPrefs with the key "savedNumber"
            PlayerPrefs.SetInt("materials", number);
            PlayerPrefs.Save();  // Save to disk immediately

            Debug.Log("Saved number: " + number);
        }
        else
        {
            Debug.LogError("Invalid number input: " + numberString);
        }*/
    }
}
