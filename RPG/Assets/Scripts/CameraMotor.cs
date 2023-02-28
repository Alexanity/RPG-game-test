using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform LookAt; // look at the player
    // creating a "box" for the camera to follow the players movement
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate() // LateUpdate is called after Update and FixedUpdate - basically first the player moves then the camera follows him
    {
        Vector3 delta = Vector3.zero ; //- difference between current frame and the next frame

        // checks if we're inside the bounds of the X axis
        float deltaX = LookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < LookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // checks if we're inside the bounds of the Y axis
        float deltaY = LookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < LookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
