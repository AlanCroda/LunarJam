using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class ForceField : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Controls controls;
        private Vector2 movementInput;
        [SerializeField] private float speed;

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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && movementInput != Vector2.zero)
            {
                print("argh");
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player" && movementInput != Vector2.zero)
            {
                print("argh");
            }
        }
    }
}
