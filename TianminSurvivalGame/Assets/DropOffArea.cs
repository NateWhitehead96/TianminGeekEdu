using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffArea : MonoBehaviour
{
    public PlayerMove player; // access to the player
    public int objectsInArea; // counter for when items go into this area

    public GameObject[] skulls; // an array (list) of all of our skulls
    public Vector3[] skullPositions; // another array to run parallel to the skulls to know their inital position
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < skulls.Length; i++) // loop through all the skulls
        {
            skullPositions[i] = skulls[i].transform.position; // save all of the starting positions of the skulls
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // when we hit space, reset skulls
        {
            for (int i = 0; i < skulls.Length; i++) // loop through all the skulls
            {
                skulls[i].transform.position = skullPositions[i]; // set all skulls back to original position
            }
            objectsInArea = 0; // reset objects in area
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Skull"))
        {
            objectsInArea += 1; // increase our object count
            if(objectsInArea == 3)
            {
                player.hasQuestItem = true; // player completes quest
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Skull"))
        {
            objectsInArea -= 1; // subtract 1
            if(objectsInArea <= 0) // if we're already at 0 or less then make objects = 0
            {
                objectsInArea = 0;
            }
        }
    }
}
