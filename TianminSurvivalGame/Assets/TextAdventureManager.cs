using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access to all things UI
using TMPro; // access to text mesh pro things

public class TextAdventureManager : MonoBehaviour
{
    public string Sentences;
    public string Sentence2;
    public int sentenceCount;
    public TMP_Text displayText;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "Hello adventurer, welcome to the game where choices matter."; // setting the display to say this on game start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayNextSentence() // when we press the button use this function
    {
        sentenceCount++; // increases by 1
        displayText.text = Sentences; // display whatever the next sentence is
    }
}
