using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player_movement : MonoBehaviour
{
    // Speed of the spaceship
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f; // Speed of rotation (for turning)
    private bool isAnimating = false;
    public Animator animator;
    // Rigidbody2D component for physics-based movement
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the spaceship
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))  // 0 is for the left mouse button
        {
            isAnimating = true;  // Set animation to true
        }
        if (Input.GetKeyUp(KeyCode.W))  // 0 is for the left mouse button
        {
            isAnimating = false;  // Set animation to true
        }
        animator.SetBool("gas", isAnimating);
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow for rotation
        float moveVertical = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow for forward/backward movement

        // Calculate movement direction
        Vector2 movement = transform.up * moveVertical;  // Move forward based on spaceship rotation

        // Apply movement (move the spaceship forward/backward)
        rb.linearVelocity = movement * moveSpeed;

        // Rotate spaceship based on input (rotate left/right)
        float rotation = -moveHorizontal * rotationSpeed * Time.deltaTime; // Negative for left rotation
        rb.MoveRotation(rb.rotation + rotation);
    }
}
