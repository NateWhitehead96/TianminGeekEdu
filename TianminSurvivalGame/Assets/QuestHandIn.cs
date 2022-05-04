using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestHandIn : MonoBehaviour
{
    public TMP_Text displayText;
    public PlayerMove player; // so we have access to the "has quest item" variable
    public string noItem; // what the NPC will say when we dont have the quest item
    public string hasItem; // what the NPC will say when we have the item

    public GameObject continueButton; // to show and hide continue button
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if(player.hasQuestItem == true)
            {
                displayText.gameObject.SetActive(true); // show text
                continueButton.SetActive(true); // show button
                displayText.text = hasItem; // this will make the text be whatever the npc will say when we have the quest item
            }
            if(player.hasQuestItem == false)
            {
                displayText.gameObject.SetActive(true); // show text
                displayText.text = noItem; // show the no item dialogue
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            displayText.gameObject.SetActive(false); // hide the text
        }
    }
}
