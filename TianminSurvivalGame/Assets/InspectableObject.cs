using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InspectableObject : MonoBehaviour
{
    public bool touchingObject; // to know if the player is touching this object
    public TMP_Text prompt; // this will tell the player to press e to interact

    public TMP_Text displayText; // this is the display if the player found the object ot not
    public bool hasQuestItem; // to know if this object has the desired quest item or not
    // Start is called before the first frame update
    void Start()
    {
        // hide both text objects
        prompt.gameObject.SetActive(false);
        displayText.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touchingObject == true && Input.GetKeyDown(KeyCode.E)) // inspect if we are touching and we press our button
        {
            if(hasQuestItem == true)
            {
                displayText.gameObject.SetActive(true);
                displayText.text = "You have found the underpants. Go return them to the wizard.";
            }
            if(hasQuestItem == false)
            {
                displayText.gameObject.SetActive(true);
                displayText.text = "You're barking up the wrong tree buddy!";
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>()) // if the player is colliding with the object
        {
            touchingObject = true; // set to true because player is now touching
            prompt.gameObject.SetActive(true); // show the prompt text
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            touchingObject = false;
            prompt.gameObject.SetActive(false);
            displayText.gameObject.SetActive(false);
        }
    }
}
