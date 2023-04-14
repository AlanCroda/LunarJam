using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class ForceField : Obstacle
    {
        private Rigidbody2D rb;
        private Controls controls;
        private Vector2 movementInput;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            controls = new Controls();
            controls.Player.Enable();
        }

        private void FixedUpdate()
        {
            movementInput = controls.Player.Move.ReadValue<Vector2>();
            rb.velocity = -Vector2.right * speed;
        }

        protected override void OnPlayerCollision(GameObject player)
        {
            if(movementInput != Vector2.zero)
            {
                print("argh");
            }
        }
    }
}
