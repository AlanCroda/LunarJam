using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    internal float speed;
    internal float acceleration;
    internal float deceleration;
    private Vector2 movementInput;

    private Controls controls;
    internal Rigidbody2D rb;

    private void Start()
    {
        controls = new Controls();
        controls.Player.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movementInput = controls.Player.Move.ReadValue<Vector2>();
        movementInput.Normalize();
        if (movementInput.magnitude > 0)
        {
            rb.velocity += movementInput * acceleration;
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), Mathf.Clamp(rb.velocity.y, -speed, speed));
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * deceleration);
        }
    }
}