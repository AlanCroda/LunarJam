using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class ForceField : Obstacle
    {
        private Controls controls;
        private Vector2 movementInput;

        private void Start()
        {
            controls = new Controls();
            controls.Player.Enable();
            transform.position = new Vector3(transform.position.x, 0f);
        }

        private void FixedUpdate()
        {
            movementInput = controls.Player.Move.ReadValue<Vector2>();
        }

        protected override void OnPlayerCollision(GameObject player)
        {
            if(movementInput != Vector2.zero)
            {
                print("argh");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && movementInput.magnitude != 0)
            {
                CameraShake.instance.Shake();
                DeathUI.instance.ShowDeathUI();
                Destroy(gameObject);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && movementInput.magnitude != 0)
            {
                CameraShake.instance.Shake();
                DeathUI.instance.ShowDeathUI();
                Destroy(gameObject);
            }
        }
    }
}
