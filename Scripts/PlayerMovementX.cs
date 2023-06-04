using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementX : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;

    private float horizontalInput;

    void FixedUpdate()
    {
        // Move the vehice forward constantly
        Vector3 moveForward = transform.forward * speed * Time.fixedDeltaTime;

        // Use the horizontal input to move the vehicle left and right
        Vector3 moveHorizontal = transform.right * horizontalInput * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveForward + moveHorizontal);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle left and right based on keyboard input
        horizontalInput = Input.GetAxis("Horizontal");    
    }
}
