using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    private Rigidbody2D avgnRB;

    public float horizontalSpeed = 10.0f;
    public float verticalSpeed = 100.0f;

    void Start()
    {
        avgnRB = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(InputX, InputY);

        avgnRB.AddForce(movement * horizontalSpeed);
    }
}
