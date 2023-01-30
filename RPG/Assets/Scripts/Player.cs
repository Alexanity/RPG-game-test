using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; // difference between position rn and where the player will be -> between frames
    private RaycastHit2D hit;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() // follows the same frame as the physics
    {
        
       // Physics2D.queriesStartInColliders = false;
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

        // Making sure we can move in this direction by casting a box there first/ if the box is null we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider != null)
        {

            //Movement
            transform.Translate(0,moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider != null)
        {

            //Movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
