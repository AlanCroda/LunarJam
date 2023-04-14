using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = -Vector3.right * speed;
    }
}
