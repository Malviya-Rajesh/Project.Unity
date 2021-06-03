using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;

    public Text logText;

    public Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;

    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation()
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionText();
        currentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] separatedWord = input.Split(delimiter);

        foreach(Action action in actions)
        {
            if(action.keyword.ToLower() == separatedWord[0])
            {
                if(separatedWord.Length > 1)
                {
                    action.RespondToInput(this, separatedWord[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing Happens ! (having trouble? type Help)";
    }
}
