using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; // difference between position rn and where the player will be -> between frames

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() // follows the same frame as the physics
    {
        //Reset MoveDelta
        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");   
        
        moveDelta = new Vector3(x,y,0);

        // testing
        //Debug.Log(x);
        //Debug.Log(y);

        //Swap sprite direction, depending on wether you're going right or left
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if(moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //Movement
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
