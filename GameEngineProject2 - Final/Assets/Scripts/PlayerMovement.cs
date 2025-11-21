using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
   
    private Rigidbody2D rb2d;
    private BoxCollider2D bc;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Gets the vertical and horizontal inputs

        
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        // Calculate movement direction
        
        if (movement.magnitude > 1f) // Normalize movement vector to prevent faster diagonal movement
        {
            movement.Normalize();
        }

        
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        // Apply movement to the object's transform
        // Time.deltaTime ensures consistent speed across different frame rates
        // Makes sure that movement is on a global scale due to how the player is able to rotate
    }
}



