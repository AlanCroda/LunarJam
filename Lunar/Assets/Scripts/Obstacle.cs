using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float size = 1.0f;
    
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = -Vector3.right * speed;
        transform.DOScale(transform.localScale * size, 0);
    }

    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnPlayerCollision(collision.gameObject);
        }
    }
    
    protected virtual void OnPlayerCollision(GameObject player)
    {

    }
}
