using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float verticalSpeed = 100.0f;

    
    void Update()
    {

        float InputX = Input.GetAxis("Horizontal") * horizontalSpeed;
        float InputY = Input.GetAxis("Vertical") * verticalSpeed;

       
    }
}
