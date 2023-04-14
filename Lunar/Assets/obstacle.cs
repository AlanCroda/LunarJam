using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private float startTime = 9.9f;
    private float currentTime;

    private ObstacleSpawner spawner;
    
    private void Start()
    {
        currentTime = startTime;
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = -Vector3.right * speed;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            rb.velocity = Vector2.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ArrowTrigger")
        {

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
