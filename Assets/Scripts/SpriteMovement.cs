using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    private Rigidbody2D avgnRB;

    public float horizontalSpeed = 10.0f;
    public float verticalSpeed = 100.0f;

    public float leftXborder;
    public float rightXborder;
    public float upperYborder;
    public float bottomYborder;

    void Start()
    {
        avgnRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (transform.position.x <= leftXborder)
        {
            transform.position = new Vector3(rightXborder-1, transform.position.y, transform.position.z);
        }
        else if (avgnRB.position.x >= rightXborder)
        {
            transform.position = new Vector3(leftXborder + 1, transform.position.y, transform.position.z);
        }
        else if (avgnRB.position.y >= upperYborder)
        {
            transform.position = new Vector3(transform.position.x, bottomYborder+1, transform.position.z);
        }
        else if (avgnRB.position.y <= bottomYborder)
        {
            transform.position = new Vector3(transform.position.x, upperYborder - 1, transform.position.z);
        }

    }

    void FixedUpdate()
    {

        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(InputX, InputY);

        avgnRB.AddForce(movement * horizontalSpeed);
    }
}
