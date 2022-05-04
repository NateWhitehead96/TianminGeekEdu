using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access to all things UI
using TMPro; // access to text mesh pro things
using UnityEngine.SceneManagement; // access to scene switching

public enum Decision
{
    none,
    yes,
    no
}

public class TextAdventureManager : MonoBehaviour
{
    public Decision decision; // tell us what decision we're in
    public string[] Sentences; // array of strings. a list of the sentences we want our player to see
    public string[] YesSentences;
    public string[] NoSentences;
    public int sentenceCount;
    //public int introSentenceCount; // how many of the sentences from our list, are used for into dialogue (the rest are for yes or no)
    //public int yesSentenceStart;
    //public int noSentenceStart;
    public TMP_Text displayText;

    public GameObject NextButton; // reference to the next button
    public GameObject YesButton; // these buttons help with displaying more dialogue
    public GameObject NoButton;

    public bool madeDecision; // know whether we made a decision or not

    public int nextLevelYes; // the level to load when we hit yes
    public int nextLevelNo; // the level to load when we hit no
    // Start is called before the first frame update
    void Start()
    {
        decision = Decision.none; // set the decision from the start to be default
        YesButton.SetActive(false); // hide button
        NoButton.SetActive(false); // hide button
        displayText.text = "Hello adventurer, welcome to the game where choices matter."; // setting the display to say this on game start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayNextSentence() // when we press the button use this function
    {
        if (decision == Decision.none) // no decision, first lines of dialogue
        {
            displayText.text = Sentences[sentenceCount]; // display whatever the next sentence is
            sentenceCount++; // increases by 1
            if (sentenceCount >= Sentences.Length)
            {
                YesButton.SetActive(true);
                NoButton.SetActive(true);
                NextButton.SetActive(false);
            }
        }
        if(decision == Decision.yes)
        {
            displayText.text = YesSentences[sentenceCount]; // display yes dialogue
            sentenceCount++;
            if(sentenceCount >= YesSentences.Length)
            {
                SceneManager.LoadScene(nextLevelYes);
            }
        }
        if(decision == Decision.no)
        {
            displayText.text = NoSentences[sentenceCount]; // display no dialogue
            sentenceCount++;
            if (sentenceCount >= NoSentences.Length)
            {
                SceneManager.LoadScene(nextLevelNo);
            }
        }
        //if(sentenceCount >= introSentenceCount) // we've run out of intro dialogue, display the yes or no
        //{
        //    // show yes and now decisions, hide next button
        //    YesButton.SetActive(true);
        //    NoButton.SetActive(true);
        //    NextButton.SetActive(false);
        //}
    }
    public void YesResponse() // the yes button thing
    {
        decision = Decision.yes; // set the decision to yes
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        NextButton.SetActive(true);
        sentenceCount = 0;
        displayText.text = YesSentences[sentenceCount];
        //if (madeDecision == true) // hit the end of it's dialogue
        //{
        //    SceneManager.LoadScene(1); // load the next scene
        //}
        //introSentenceCount = noSentenceStart; // set the amount of sentences we can see to the limit of our sentences
        //YesButton.SetActive(false);
        //NoButton.SetActive(false);
        //NextButton.SetActive(true);
        //sentenceCount = yesSentenceStart; // the count will start from the yes
        //displayText.text = Sentences[sentenceCount]; // display the first line of text for the answer
        //madeDecision = true;
    }
    public void NoResponse() // the no button thing
    {
        decision = Decision.no; // set the decision to no
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        NextButton.SetActive(true);
        sentenceCount = 0;
        displayText.text = NoSentences[sentenceCount];
        //introSentenceCount = Sentences.Length; // set the amount of sentences we can see to the limit of our sentences
        //YesButton.SetActive(false);
        //NoButton.SetActive(false);
        //NextButton.SetActive(true);
        //sentenceCount = noSentenceStart; // the count will start from the no
        //displayText.text = Sentences[sentenceCount];// display the first line of text for the answer
    }
}
