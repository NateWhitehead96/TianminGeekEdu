using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int moveSpeed; // a whole number that will be how fast the player can move
    public SpriteRenderer sprite; // access to flipping our sprite left and right
    public float xBounds; // how far left and right we can go
    public float yBounds; // how high or low we can go
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // link our sprite to its renderer
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // move up with W or up arrow
        {
            if (transform.position.y < yBounds) // make sure we're lower than the top bounds
            { 
                transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime); 
            }
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // move down with S or down arrow
        {
            if(transform.position.y > -yBounds) // make sure we're above the lowest bounds
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // move right with D or right arrow
        {
            if (transform.position.x < xBounds) // make sure we're not too far right
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
                sprite.flipX = true; // flip the sprite to look to the right
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // move left with A or left arrow
        {
            if (transform.position.x > -xBounds) // make sure we're not too far left
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
                sprite.flipX = false; // flip the sprite to look to the left
            }
        }
    }
}
