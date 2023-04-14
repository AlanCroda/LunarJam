using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 movementInput;

    internal Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }
}